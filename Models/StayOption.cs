namespace RouteRebels.Api.Models
{
    public class StayOption
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Hotel, Homestay, Hostel
        public string PriceRange { get; set; } = string.Empty; // e.g. "₹800-1500/night"
        public string Description { get; set; } = string.Empty;
    }
}