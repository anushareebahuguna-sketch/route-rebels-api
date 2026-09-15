namespace RouteRebels.Api.Models
{
    public class CrowdForecast
    {
        public DateTime Date { get; set; }

        public string Day { get; set; } = string.Empty;

        public int PressureScore { get; set; }

        public string CrowdLevel { get; set; } = string.Empty;

        public bool IsRecommendedDay { get; set; }
    }
}