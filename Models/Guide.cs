namespace RouteRebels.Api.Models
{
    public class Guide
    {
        public string Name { get; set; } = string.Empty;
        public string PricePerDay { get; set; } = string.Empty; // e.g. "₹1200/day"
        public string Languages { get; set; } = string.Empty; // e.g. "Hindi, English"
        public string ContactInfo { get; set; } = string.Empty;
    }
}