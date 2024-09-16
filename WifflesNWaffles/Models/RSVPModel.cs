using System.ComponentModel.DataAnnotations;
using WifflesNWaffles.Enums;

namespace WifflesNWaffles.Models
{
    

    public class RSVPModel
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; } 

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? Topping { get; set; }

        public AttendanceStatus Attendance { get; set; }


    }
}
