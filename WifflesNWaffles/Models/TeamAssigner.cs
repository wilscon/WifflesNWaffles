namespace WifflesNWaffles.Models
{
    public class TeamAssigner
    {
        public static void AssignTeams(List<RSVPDBModel> attendees, out List<AttendeesModel> Team1, out List<AttendeesModel> Team2)
        {
            // Randomly shuffle the list using LINQ's OrderBy with a random key
            Random rng = new Random();
            var shuffledAttendees = attendees.OrderBy(a => rng.Next()).ToList();

            // Calculate the half point
            int halfCount = shuffledAttendees.Count / 2;

            // Initialize Team1 and Team2
            Team1 = shuffledAttendees.Take(halfCount)
                                     .Select(a => new AttendeesModel { FirstName = a.FirstName, LastName = a.LastName })
                                     .ToList();
            Team2 = shuffledAttendees.Skip(halfCount)
                                     .Select(a => new AttendeesModel { FirstName = a.FirstName, LastName = a.LastName })
                                     .ToList();
        }


    }
}
