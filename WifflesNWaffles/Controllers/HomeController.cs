using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using WifflesNWaffles.Data;
using WifflesNWaffles.Models;
using WifflesNWaffles.Enums;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;

namespace WifflesNWaffles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Attendees() {

            
            
            
            IEnumerable<RSVPDBModel> attendees = await _context.attendees.ToListAsync();
            List<AttendeesModel> people = new List<AttendeesModel> {};
            
            foreach (var attendee in attendees)
            {
                string base64Image = GenerateProfileImageBase64(attendee.FirstName[0].ToString() + attendee.LastName[0].ToString(), 40, 40);

                people.Add(new AttendeesModel { FirstName = attendee.FirstName, LastName = attendee.LastName, Topping = attendee.Topping, Attendance = (AttendanceStatus)attendee.Attendance, ProfileImage = base64Image });
               
            }


           

            return View("Attendees",people);
        }

        [HttpGet]
        public async Task<IActionResult> Event() { 
        
            return View("Event");
        
        }

        public async Task<IActionResult> History() {

            return View("History");
        }

        [HttpGet]
        public async Task<IActionResult> RSVP() {


            return View("RSVP");
        }

        [HttpGet]
        public async Task<IActionResult> Trophy() {

            return View("Trophy");
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] RSVPModel form)
        {

           

            RSVPDBModel Model = new RSVPDBModel
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                Topping = form.Topping,
                Attendance = (int)form.Attendance,

            };



            
            try
            {
                _context.attendees.Add(Model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                
                Console.WriteLine("An error occurred while saving changes: " + ex.Message);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }



            return Ok(new { success = true, message = "RSVP form received successfully." });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static string GenerateProfileImageBase64(string initials, int width, int height)
        {
            using (Bitmap bitmap = GenerateProfileImage(initials, width, height))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save the image to the memory stream as PNG
                    bitmap.Save(ms, ImageFormat.Png);

                    // Convert the byte array to Base64 string
                    byte[] imageBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    return "data:image/png;base64," + base64String;
                }
            }
        }

        public static Bitmap GenerateProfileImage(string initials, int width, int height)
        {
            Random random = new Random();

            // Create a blank canvas
            Bitmap bitmap = new Bitmap(width, height);

            // Create random background color
            Color backgroundColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            // Fill the canvas with the background color
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(backgroundColor);

                // Create font for initials
                System.Drawing.Font font = new System.Drawing.Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

                // Set text color (contrast to background)
                Brush textBrush = new SolidBrush(Color.White);

                // Measure the size of the initials text
                SizeF textSize = g.MeasureString(initials, font);

                // Draw the initials in the center of the image
                g.DrawString(initials, font, textBrush,
                             (width - textSize.Width) / 2,
                             (height - textSize.Height) / 2);
            }

            return bitmap;
        }
    }

    
}
