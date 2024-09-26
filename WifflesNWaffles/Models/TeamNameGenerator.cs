namespace WifflesNWaffles.Models
{
    public class TeamNameGenerator
    {
        private static readonly string[] adjectives = { "Mighty", "Fierce", "Brave", "Swift", "Fearless", "Bold", "Epic", "Stealthy", "Powerful" };
        private static readonly string[] nouns = { "Warriors", "Tigers", "Eagles", "Lions", "Sharks", "Falcons", "Panthers", "Dragons", "Wolves", "Knights" };

        public static string GenerateRandomTeamName()
        {
            Random random = new Random();
            string randomAdjective = adjectives[random.Next(adjectives.Length)];
            string randomNoun = nouns[random.Next(nouns.Length)];

            return $"{randomAdjective} {randomNoun}";
        }

    }
}
