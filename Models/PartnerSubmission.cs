namespace RouteRebels.Api.Models
{
    public class PartnerSubmission
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}