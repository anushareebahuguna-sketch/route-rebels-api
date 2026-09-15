using Microsoft.AspNetCore.Mvc;
using RouteRebels.Api.Models;

namespace RouteRebels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalExperiencesController : ControllerBase
    {
        private static readonly List<LocalExperience> Experiences = new()
        {
            // ---------------- MUSSOORIE ----------------

            new LocalExperience
            {
                Id = 1,
                DestinationId = 10,
                Name = "Garhwali Folk Experience",
                Type = "Culture",
                Description = "Experience traditional Garhwali music, stories and local cultural traditions with community members.",
                PriceRange = "₹300-600",
                Duration = "1-2 hours",
                Location = "Nearby mountain villages",
                ImageUrl = "https://picsum.photos/seed/garhwali-culture/800/600"
            },

            new LocalExperience
            {
                Id = 2,
                DestinationId = 10,
                Name = "Mountain Village Walk",
                Type = "Nature",
                Description = "Walk through quiet mountain villages and discover everyday Himalayan life away from crowded tourist areas.",
                PriceRange = "₹400-800",
                Duration = "2-3 hours",
                Location = "Nearby mountain villages",
                ImageUrl = "https://picsum.photos/seed/villagewalk/800/600"
            },

            new LocalExperience
            {
                Id = 3,
                DestinationId = 10,
                Name = "Traditional Wool Craft Workshop",
                Type = "Art & Craft",
                Description = "Meet local makers and learn how traditional wool products are created using regional techniques.",
                PriceRange = "₹500-1000",
                Duration = "2 hours",
                Location = "Local artisan workshop",
                ImageUrl = "https://picsum.photos/seed/woolcraft/800/600"
            },

            new LocalExperience
            {
                Id = 4,
                DestinationId = 10,
                Name = "Garhwali Cooking Experience",
                Type = "Food",
                Description = "Learn to prepare traditional mountain dishes using locally sourced ingredients.",
                PriceRange = "₹600-1000",
                Duration = "2-3 hours",
                Location = "Local homestay",
                ImageUrl = "https://picsum.photos/seed/garhwali-food/800/600"
            },

            // ---------------- DHANAULTI ----------------

            new LocalExperience
            {
                Id = 5,
                DestinationId = 11,
                Name = "Himalayan Forest Trek",
                Type = "Adventure",
                Description = "Explore peaceful Himalayan forest trails with a local guide.",
                PriceRange = "₹400-900",
                Duration = "3-4 hours",
                Location = "Dhanaulti Forest",
                ImageUrl = "https://picsum.photos/seed/dhanaulti-trek/800/600"
            },

            new LocalExperience
            {
                Id = 6,
                DestinationId = 11,
                Name = "Mountain Photography Walk",
                Type = "Photography",
                Description = "Capture mountain landscapes and everyday village life with a local photographer.",
                PriceRange = "₹300-700",
                Duration = "2 hours",
                Location = "Dhanaulti villages",
                ImageUrl = "https://picsum.photos/seed/mountain-photo/800/600"
            },

            new LocalExperience
            {
                Id = 7,
                DestinationId = 11,
                Name = "Himalayan Local Food Workshop",
                Type = "Food",
                Description = "Discover traditional mountain recipes and eat a freshly prepared local meal.",
                PriceRange = "₹500-900",
                Duration = "2 hours",
                Location = "Local homestay",
                ImageUrl = "https://picsum.photos/seed/himalayan-food/800/600"
            },

            // ---------------- JAIPUR ----------------

            new LocalExperience
            {
                Id = 8,
                DestinationId = 2,
                Name = "Rajasthani Block Printing",
                Type = "Art & Craft",
                Description = "Learn traditional block printing directly from local artisans.",
                PriceRange = "₹500-1200",
                Duration = "2 hours",
                Location = "Jaipur artisan quarter",
                ImageUrl = "https://picsum.photos/seed/blockprint/800/600"
            },

            new LocalExperience
            {
                Id = 9,
                DestinationId = 2,
                Name = "Rajasthani Food Walk",
                Type = "Food",
                Description = "Explore traditional flavours and family-run food spots beyond standard tourist restaurants.",
                PriceRange = "₹700-1500",
                Duration = "2-3 hours",
                Location = "Old Jaipur",
                ImageUrl = "https://picsum.photos/seed/rajasthani-food/800/600"
            },

            // ---------------- BUNDI ----------------

            new LocalExperience
            {
                Id = 10,
                DestinationId = 3,
                Name = "Miniature Painting Workshop",
                Type = "Art & Craft",
                Description = "Meet local artists and learn about the traditional miniature painting style of Rajasthan.",
                PriceRange = "₹500-1000",
                Duration = "2 hours",
                Location = "Bundi artisan area",
                ImageUrl = "https://picsum.photos/seed/miniatureart/800/600"
            },

            new LocalExperience
            {
                Id = 11,
                DestinationId = 3,
                Name = "Heritage Lane Walk",
                Type = "Culture",
                Description = "Discover historic lanes, local homes and lesser-known stories of Bundi.",
                PriceRange = "₹300-600",
                Duration = "2 hours",
                Location = "Old Bundi",
                ImageUrl = "https://picsum.photos/seed/bundiwalk/800/600"
            },

            // ---------------- DELHI ----------------

            new LocalExperience
            {
                Id = 12,
                DestinationId = 4,
                Name = "Old Delhi Food Experience",
                Type = "Food",
                Description = "Taste traditional street food through small local vendors and family-run eateries.",
                PriceRange = "₹500-1000",
                Duration = "2-3 hours",
                Location = "Old Delhi",
                ImageUrl = "https://picsum.photos/seed/olddelhifood/800/600"
            },

            new LocalExperience
            {
                Id = 13,
                DestinationId = 5,
                Name = "Hauz Khas Heritage Walk",
                Type = "Culture",
                Description = "Discover historic architecture, art spaces and local cafés away from conventional tourist routes.",
                PriceRange = "₹300-700",
                Duration = "2 hours",
                Location = "Hauz Khas",
                ImageUrl = "https://picsum.photos/seed/hauzkhaswalk/800/600"
            },

            // ---------------- GOA ----------------

            new LocalExperience
            {
                Id = 14,
                DestinationId = 6,
                Name = "Traditional Goan Cooking",
                Type = "Food",
                Description = "Learn traditional Goan recipes from a local home cook.",
                PriceRange = "₹700-1200",
                Duration = "2-3 hours",
                Location = "Local Goan home",
                ImageUrl = "https://picsum.photos/seed/goancooking/800/600"
            },

            new LocalExperience
            {
                Id = 15,
                DestinationId = 7,
                Name = "Local Fisherman Experience",
                Type = "Culture",
                Description = "Learn about traditional coastal life and fishing practices from local community members.",
                PriceRange = "₹500-1000",
                Duration = "2 hours",
                Location = "Palolem",
                ImageUrl = "https://picsum.photos/seed/fisherman/800/600"
            },

            // ---------------- KERALA ----------------

            new LocalExperience
            {
                Id = 16,
                DestinationId = 8,
                Name = "Traditional Kerala Cooking",
                Type = "Food",
                Description = "Prepare authentic Kerala dishes using traditional spices and local ingredients.",
                PriceRange = "₹700-1200",
                Duration = "2-3 hours",
                Location = "Local homestay",
                ImageUrl = "https://picsum.photos/seed/keralacooking/800/600"
            },

            new LocalExperience
            {
                Id = 17,
                DestinationId = 9,
                Name = "Tea Estate Walk",
                Type = "Nature",
                Description = "Walk through a local tea estate and learn about tea cultivation.",
                PriceRange = "₹400-800",
                Duration = "2 hours",
                Location = "Munnar",
                ImageUrl = "https://picsum.photos/seed/teaestate/800/600"
            },

            // ---------------- CHOPTA ----------------

            new LocalExperience
            {
                Id = 18,
                DestinationId = 1,
                Name = "Himalayan Village Experience",
                Type = "Culture",
                Description = "Spend time with local mountain communities and experience traditional Himalayan life.",
                PriceRange = "₹300-700",
                Duration = "2-3 hours",
                Location = "Villages near Chopta",
                ImageUrl = "https://picsum.photos/seed/himalayanvillage/800/600"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<LocalExperience>> GetAll(
            [FromQuery] int? destinationId,
            [FromQuery] string? type)
        {
            IEnumerable<LocalExperience> result = Experiences;

            if (destinationId.HasValue)
            {
                result = result.Where(x =>
                    x.DestinationId == destinationId.Value);
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                result = result.Where(x =>
                    x.Type.Equals(
                        type,
                        StringComparison.OrdinalIgnoreCase));
            }

            return Ok(result.ToList());
        }
    }
}