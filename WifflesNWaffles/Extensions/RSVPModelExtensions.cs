using WifflesNWaffles.Models;

namespace WifflesNWaffles.Extensions
{
    public static class RSVPModelExtensions
    {
        public static RSVPDBModel ToDBModel(this RSVPModel form)
        {
            return new RSVPDBModel
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                Topping = form.Topping,
                Attendance = (int)form.Attendance,
                Year = DateTime.Now.Year.ToString(),
                id = Guid.NewGuid()
            };
        }
    }
}
