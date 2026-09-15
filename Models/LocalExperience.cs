namespace RouteRebels.Api.Models
{
    public class LocalExperience
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string PriceRange { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public bool Local { get; set; } = true;
    }
}