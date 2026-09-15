namespace RouteRebels.Api.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Category { get; set; } = string.Empty;
        public string BudgetTier { get; set; } = string.Empty;
        public string CrowdLevel { get; set; } = string.Empty;
        public int? AlternativeDestinationId { get; set; }

        // Recommendation system fields
        public string DestinationType { get; set; } = string.Empty;
        public List<string> ExperienceTags { get; set; } = new();

        public List<string> ImageUrls { get; set; } = new();
        public List<string> VideoUrls { get; set; } = new();

        public List<Activity> Activities { get; set; } = new();
        public List<StayOption> StayOptions { get; set; } = new();
        public List<FoodOption> FoodOptions { get; set; } = new();
        public List<Guide> Guides { get; set; } = new();
    }
}