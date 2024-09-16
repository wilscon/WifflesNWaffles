using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WifflesNWaffles.Models
{
    [Table("attendees", Schema = "WIFFLESNWAFFLES")]
    public class RSVPDBModel
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        
        [Key]
        public string Email { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        public string? Topping { get; set; }

        public int Attendance { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }


    }
}
