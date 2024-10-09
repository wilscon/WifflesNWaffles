using WifflesNWaffles.Enums;
using WifflesNWaffles.Models;
using WifflesNWaffles.Utilities;

namespace WifflesNWaffles.Extensions
{
    public static class RSVPDBModelExtensions
    {
        public static AttendeesModel toAttendeesModel(this RSVPDBModel model)
        {
            return new AttendeesModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Topping = model.Topping,
                Attendance = (AttendanceStatus)model.Attendance,
                ProfileImage = ProfileImageGenerator.GenerateProfileImageBase64(model.FirstName[0].ToString() + model.LastName[0].ToString(), 40, 40),
            };
        }
    }
}
