using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using WifflesNWaffles.Enums;

namespace WifflesNWaffles.Models
{
    public class AttendeesModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string? Topping { get; set; }

        public AttendanceStatus Attendance { get; set; }

        public String? ProfileImage { get; set; }

    }
}
