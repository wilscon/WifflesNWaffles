using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WifflesNWaffles.Data;
using WifflesNWaffles.Models;
using WifflesNWaffles.Extensions;

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

            IEnumerable<RSVPDBModel> attendeesDB = await _context.attendees.Where(a => a.Year == "2024").ToListAsync();
            List<AttendeesModel> attendees = new List<AttendeesModel> {};
            
            foreach (var attendee in attendeesDB)
            {
                attendees.Add(attendee.toAttendeesModel());  
            }

            return View("Attendees",attendees);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeYear(string year) {


            IEnumerable<RSVPDBModel> attendeesDB = await _context.attendees.Where(a => a.Year == year).ToListAsync();

            List<AttendeesModel> attendees = new List<AttendeesModel> { };

            foreach (var attendee in attendeesDB)
            {
                attendees.Add(attendee.toAttendeesModel());
            }

            return PartialView("Views/Home/_AttendeesTable.cshtml", attendees);

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
        public async Task<IActionResult> Teams() {

            List<RSVPDBModel> attendees = await _context.attendees.ToListAsync();
           
            TeamsModel teams = new TeamsModel();
            List<AttendeesModel> Team1;
            List<AttendeesModel> Team2;
            TeamAssigner.AssignTeams(attendees, out Team1, out Team2);
            teams.Team1 = Team1;
            teams.Team2 = Team2;
            teams.Team1Name = TeamNameGenerator.GenerateRandomTeamName();
            teams.Team2Name = TeamNameGenerator.GenerateRandomTeamName();

            return View("Teams",teams);
        }

        [HttpGet]
        public async Task<IActionResult> Trophy() {

            return View("Trophy");
        }


        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] RSVPModel form)
        {
            RSVPDBModel Model = form.ToDBModel();

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

    }

    
}
