namespace RouteRebels.Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public string DestinationName { get; set; } = string.Empty;
        public string GuideName { get; set; } = string.Empty;
        public string TravelerName { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public DateTime TravelDate { get; set; }
        public DateTime BookedAt { get; set; } = DateTime.Now;
    }
}