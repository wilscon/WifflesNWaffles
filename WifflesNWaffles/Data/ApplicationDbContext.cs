using Microsoft.EntityFrameworkCore;
using WifflesNWaffles.Models;

namespace WifflesNWaffles.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }



        public DbSet<RSVPDBModel> attendees { get; set; }
    }
}
