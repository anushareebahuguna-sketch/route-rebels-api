using Microsoft.AspNetCore.Mvc;
using RouteRebels.Api.Models;

namespace RouteRebels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationsController : ControllerBase
    {
        private static readonly List<Destination> Destinations = new()
        {
            new Destination
            {
                Id = 1,
                Name = "Chopta",
                Description = "A quiet Himalayan meadow village, often called 'Mini Switzerland of India', far less crowded than typical hill stations.",
                State = "Uttarakhand",
                City = "Chopta",
                Latitude = 30.4167,
                Longitude = 79.1667,
                Category = "Hidden Gem",
                BudgetTier = "Low",
                CrowdLevel = "Low",
                DestinationType = "Hill Station",
                ExperienceTags = new()
                {
                    "Mountain",
                    "Nature",
                    "Scenic",
                    "Trekking",
                    "Relaxation"
                },
                ImageUrls = new() { "https://picsum.photos/seed/chopta/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Tungnath Trek",
                        Description = "Trek to one of the highest Shiva temples in the world."
                    },
                    new Activity
                    {
                        Name = "Chandrashila Summit",
                        Description = "Sunrise trek with panoramic Himalayan views."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Chopta Meadow Homestay",
                        Type = "Homestay",
                        PriceRange = "₹800-1200/night",
                        Description = "Family-run homestay with mountain views."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Local Dhaba",
                        Type = "Local Eatery",
                        Description = "Simple Garhwali food, hot maggi and chai."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Ramesh Bisht",
                        PricePerDay = "₹1000/day",
                        Languages = "Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 2,
                Name = "Jaipur City Palace",
                Description = "The Pink City's royal palace complex, one of Rajasthan's most visited landmarks.",
                State = "Rajasthan",
                City = "Jaipur",
                Latitude = 26.9124,
                Longitude = 75.7873,
                Category = "Popular",
                BudgetTier = "Medium",
                CrowdLevel = "High",
                AlternativeDestinationId = 3,
                DestinationType = "Heritage",
                ExperienceTags = new()
                {
                    "History",
                    "Heritage",
                    "Architecture",
                    "Culture",
                    "Photography"
                },
                ImageUrls = new() { "https://picsum.photos/seed/jaipur/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Amber Fort Tour",
                        Description = "Guided tour of the iconic hilltop fort."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Hotel Pearl Palace",
                        Type = "Hotel",
                        PriceRange = "₹1800-3000/night",
                        Description = "Popular budget-boutique hotel."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Laxmi Misthan Bhandar",
                        Type = "Restaurant",
                        Description = "Famous for Rajasthani sweets and snacks."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Vikram Singh",
                        PricePerDay = "₹1400/day",
                        Languages = "Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 3,
                Name = "Bundi",
                Description = "A lesser-known Rajasthani town with stepwells, painted havelis, and a fort — a quieter alternative to Jaipur.",
                State = "Rajasthan",
                City = "Bundi",
                Latitude = 25.4305,
                Longitude = 75.6499,
                Category = "Hidden Gem",
                BudgetTier = "Low",
                CrowdLevel = "Low",
                DestinationType = "Heritage",
                ExperienceTags = new()
                {
                    "History",
                    "Heritage",
                    "Architecture",
                    "Culture",
                    "Photography"
                },
                ImageUrls = new() { "https://picsum.photos/seed/bundi/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Stepwell Exploration",
                        Description = "Visit Raniji ki Baori and other historic stepwells."
                    },
                    new Activity
                    {
                        Name = "Bundi Palace Tour",
                        Description = "Explore the frescoed palace overlooking the town."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Haveli Braj Bhushanjee",
                        Type = "Heritage Homestay",
                        PriceRange = "₹1500-2200/night",
                        Description = "Heritage haveli converted into a homestay."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Rainbow Cafe",
                        Type = "Cafe",
                        Description = "Rooftop cafe overlooking the palace."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Mahendra Sharma",
                        PricePerDay = "₹1000/day",
                        Languages = "Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 4,
                Name = "India Gate",
                Description = "One of Delhi's most iconic war memorials, always bustling with visitors.",
                State = "Delhi",
                City = "New Delhi",
                Latitude = 28.6129,
                Longitude = 77.2295,
                Category = "Popular",
                BudgetTier = "Low",
                CrowdLevel = "High",
                AlternativeDestinationId = 5,
                DestinationType = "Landmark",
                ExperienceTags = new()
                {
                    "History",
                    "Culture",
                    "Photography",
                    "City",
                    "Family"
                },
                ImageUrls = new() { "https://picsum.photos/seed/indiagate/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Evening Lawn Walk",
                        Description = "Popular evening spot for families and food stalls nearby."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Hotel Connaught",
                        Type = "Hotel",
                        PriceRange = "₹2200-3500/night",
                        Description = "Centrally located hotel near CP."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "India Gate Chaat Stalls",
                        Type = "Street Food",
                        Description = "Classic Delhi street snacks near the lawns."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Rohit Malhotra",
                        PricePerDay = "₹1200/day",
                        Languages = "Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 5,
                Name = "Hauz Khas Village",
                Description = "A quieter heritage-meets-cafe neighborhood with a medieval reservoir and ruins, far less crowded than central Delhi spots.",
                State = "Delhi",
                City = "Hauz Khas",
                Latitude = 28.5535,
                Longitude = 77.1892,
                Category = "Hidden Gem",
                BudgetTier = "Medium",
                CrowdLevel = "Low",
                DestinationType = "Urban Heritage",
                ExperienceTags = new()
                {
                    "History",
                    "Heritage",
                    "Culture",
                    "Cafe",
                    "Photography"
                },
                ImageUrls = new() { "https://picsum.photos/seed/hauzkhas/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Hauz Khas Ruins Walk",
                        Description = "Explore the 14th-century madrasa and tomb ruins by the lake."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Lutyens Boutique Stay",
                        Type = "Homestay",
                        PriceRange = "₹2000-3000/night",
                        Description = "Boutique stay near the village."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Yeti - The Himalayan Kitchen",
                        Type = "Restaurant",
                        Description = "Popular cafe overlooking the ruins."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Ananya Kapoor",
                        PricePerDay = "₹1300/day",
                        Languages = "Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 6,
                Name = "Baga Beach",
                Description = "Goa's most popular and crowded beach, known for nightlife and water sports.",
                State = "Goa",
                City = "Baga",
                Latitude = 15.5553,
                Longitude = 73.7517,
                Category = "Popular",
                BudgetTier = "Medium",
                CrowdLevel = "High",
                AlternativeDestinationId = 7,
                DestinationType = "Beach",
                ExperienceTags = new()
                {
                    "Beach",
                    "Water Sports",
                    "Nightlife",
                    "Sea",
                    "Entertainment"
                },
                ImageUrls = new() { "https://picsum.photos/seed/bagabeach/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Water Sports",
                        Description = "Jet-skiing, parasailing, and banana boat rides."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Baga Beach Resort",
                        Type = "Resort",
                        PriceRange = "₹2500-4500/night",
                        Description = "Beachfront resort with pool."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Britto's",
                        Type = "Restaurant",
                        Description = "Iconic beachside seafood shack."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Joaquim Fernandes",
                        PricePerDay = "₹1200/day",
                        Languages = "Konkani, Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 7,
                Name = "Palolem Beach",
                Description = "A calmer, crescent-shaped beach in South Goa — a quieter alternative to the North Goa party beaches.",
                State = "Goa",
                City = "Palolem",
                Latitude = 15.0100,
                Longitude = 74.0233,
                Category = "Hidden Gem",
                BudgetTier = "Low",
                CrowdLevel = "Low",
                DestinationType = "Beach",
                ExperienceTags = new()
                {
                    "Beach",
                    "Nature",
                    "Sea",
                    "Relaxation",
                    "Photography"
                },
                ImageUrls = new() { "https://picsum.photos/seed/palolem/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Dolphin Watching Boat Trip",
                        Description = "Morning boat rides to spot dolphins offshore."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Palolem Beach Huts",
                        Type = "Beach Hut",
                        PriceRange = "₹900-1500/night",
                        Description = "Simple huts right on the sand."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Ourem 88",
                        Type = "Restaurant",
                        Description = "Popular fusion restaurant near the beach."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Savio D'Souza",
                        PricePerDay = "₹1000/day",
                        Languages = "Konkani, Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 8,
                Name = "Alleppey Backwaters",
                Description = "Kerala's famous houseboat backwaters — scenic but can get busy during peak season.",
                State = "Kerala",
                City = "Alappuzha",
                Latitude = 9.4981,
                Longitude = 76.3388,
                Category = "Popular",
                BudgetTier = "Medium",
                CrowdLevel = "Medium",
                AlternativeDestinationId = 9,
                DestinationType = "Backwaters",
                ExperienceTags = new()
                {
                    "Nature",
                    "Water",
                    "Scenic",
                    "Relaxation",
                    "Boating"
                },
                ImageUrls = new() { "https://picsum.photos/seed/alleppey/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Houseboat Cruise",
                        Description = "Overnight or day cruises through the backwaters."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Alleppey Houseboat Stay",
                        Type = "Houseboat",
                        PriceRange = "₹4000-7000/night",
                        Description = "Traditional Kerala houseboat stay."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Houseboat Onboard Kitchen",
                        Type = "Local Eatery",
                        Description = "Fresh Kerala seafood meals cooked onboard."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Biju Thomas",
                        PricePerDay = "₹1300/day",
                        Languages = "Malayalam, Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 9,
                Name = "Munnar Hills",
                Description = "Misty tea-garden hills in Kerala's Western Ghats — a quieter, cooler alternative to the busy backwaters.",
                State = "Kerala",
                City = "Munnar",
                Latitude = 10.0889,
                Longitude = 77.0595,
                Category = "Hidden Gem",
                BudgetTier = "Medium",
                CrowdLevel = "Low",
                DestinationType = "Hill Station",
                ExperienceTags = new()
                {
                    "Mountain",
                    "Nature",
                    "Scenic",
                    "Trekking",
                    "Relaxation"
                },
                ImageUrls = new() { "https://picsum.photos/seed/munnar/800/600" },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Tea Garden Walk",
                        Description = "Walk through sprawling tea plantations with guided tastings."
                    },
                    new Activity
                    {
                        Name = "Eravikulam National Park Visit",
                        Description = "Home to the endangered Nilgiri Tahr."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Munnar Tea Estate Homestay",
                        Type = "Homestay",
                        PriceRange = "₹1500-2500/night",
                        Description = "Homestay amid the tea plantations."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Rapsy Restaurant",
                        Type = "Local Eatery",
                        Description = "Popular local spot for Kerala meals."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Sunil Kumar",
                        PricePerDay = "₹1100/day",
                        Languages = "Malayalam, Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 10,
                Name = "Mussoorie",
                Description = "A famous Himalayan hill station known for mountain views, colonial charm, scenic viewpoints, and popular trekking routes. It can become heavily crowded during peak periods.",
                State = "Uttarakhand",
                City = "Mussoorie",
                Latitude = 30.4598,
                Longitude = 78.0664,
                Category = "Popular",
                BudgetTier = "Medium",
                CrowdLevel = "High",
                AlternativeDestinationId = 11,
                DestinationType = "Hill Station",
                ExperienceTags = new()
                {
                    "Mountain",
                    "Nature",
                    "Scenic",
                    "Trekking",
                    "Relaxation",
                    "Colonial"
                },
                ImageUrls = new()
                {
                    "https://picsum.photos/seed/mussoorie/800/600"
                },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Mall Road Walk",
                        Description = "Explore the famous Mall Road with mountain views, shops, and cafes."
                    },
                    new Activity
                    {
                        Name = "Kempty Falls Visit",
                        Description = "Visit one of the most popular waterfalls near Mussoorie."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Mussoorie Valley Hotel",
                        Type = "Hotel",
                        PriceRange = "₹2000-3500/night",
                        Description = "Comfortable stay with mountain views."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Mountain View Cafe",
                        Type = "Cafe",
                        Description = "Cafe serving local snacks and hot beverages with scenic views."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Amit Rawat",
                        PricePerDay = "₹1200/day",
                        Languages = "Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            },

            new Destination
            {
                Id = 11,
                Name = "Dhanaulti",
                Description = "A peaceful Himalayan hill destination near Mussoorie, offering pine forests, mountain scenery, fresh air, and a much quieter experience.",
                State = "Uttarakhand",
                City = "Dhanaulti",
                Latitude = 30.4167,
                Longitude = 78.2667,
                Category = "Hidden Gem",
                BudgetTier = "Medium",
                CrowdLevel = "Low",
                DestinationType = "Hill Station",
                ExperienceTags = new()
                {
                    "Mountain",
                    "Nature",
                    "Scenic",
                    "Trekking",
                    "Relaxation",
                    "Forest"
                },
                ImageUrls = new()
                {
                    "https://picsum.photos/seed/dhanaulti/800/600"
                },
                Activities = new()
                {
                    new Activity
                    {
                        Name = "Eco Park Walk",
                        Description = "Walk through peaceful deodar and cedar forests at Eco Park."
                    },
                    new Activity
                    {
                        Name = "Forest Trek",
                        Description = "Explore quiet forest trails with panoramic Himalayan views."
                    }
                },
                StayOptions = new()
                {
                    new StayOption
                    {
                        Name = "Dhanaulti Forest Homestay",
                        Type = "Homestay",
                        PriceRange = "₹1800-3000/night",
                        Description = "Peaceful mountain stay surrounded by forests."
                    }
                },
                FoodOptions = new()
                {
                    new FoodOption
                    {
                        Name = "Dhanaulti Local Cafe",
                        Type = "Local Eatery",
                        Description = "Simple local food, snacks, and hot chai."
                    }
                },
                Guides = new()
                {
                    new Guide
                    {
                        Name = "Rajesh Negi",
                        PricePerDay = "₹1100/day",
                        Languages = "Hindi, English",
                        ContactInfo = "+91-XXXXXXXXXX"
                    }
                }
            }
        };

        private static double CalculateDistanceKm(
            double latitude1,
            double longitude1,
            double latitude2,
            double longitude2)
        {
            const double earthRadiusKm = 6371.0;

            double dLat = DegreesToRadians(latitude2 - latitude1);
            double dLon = DegreesToRadians(longitude2 - longitude1);

            double lat1 = DegreesToRadians(latitude1);
            double lat2 = DegreesToRadians(latitude2);

            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(lat1) * Math.Cos(lat2) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(
                Math.Sqrt(a),
                Math.Sqrt(1 - a));

            return earthRadiusKm * c;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        private static string PredictCrowdForDate(
            Destination destination,
            DateTime date)
        {
            int score =
                destination.Category == "Popular"
                    ? 2
                    : 0;

            bool isWeekend =
                date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday;

            if (isWeekend)
                score += 1;

            if (score <= 0)
                return "Low";

            if (score == 1)
                return "Medium";

            return "High";
        }

        // =========================================================
        // FEATURE #6
        // Multiple Alternative Types
        // =========================================================

        private static string GetAlternativeType(
            Destination original,
            Destination alternative)
        {
            string originalType =
                original.DestinationType.ToLowerInvariant();

            string alternativeType =
                alternative.DestinationType.ToLowerInvariant();

            // Direct same-type alternative
            if (originalType == alternativeType)
                return "Same Experience";

            // Experience-based alternatives
            if (original.ExperienceTags.Contains(
                    "Heritage",
                    StringComparer.OrdinalIgnoreCase) &&
                alternative.ExperienceTags.Contains(
                    "Heritage",
                    StringComparer.OrdinalIgnoreCase))
            {
                return "Heritage Alternative";
            }

            if (original.ExperienceTags.Contains(
                    "Beach",
                    StringComparer.OrdinalIgnoreCase) &&
                alternative.ExperienceTags.Contains(
                    "Beach",
                    StringComparer.OrdinalIgnoreCase))
            {
                return "Beach Alternative";
            }

            if (original.ExperienceTags.Contains(
                    "Mountain",
                    StringComparer.OrdinalIgnoreCase) &&
                alternative.ExperienceTags.Contains(
                    "Mountain",
                    StringComparer.OrdinalIgnoreCase))
            {
                return "Nature & Hill Alternative";
            }

            if (original.ExperienceTags.Contains(
                    "Nature",
                    StringComparer.OrdinalIgnoreCase) &&
                alternative.ExperienceTags.Contains(
                    "Nature",
                    StringComparer.OrdinalIgnoreCase))
            {
                return "Nature Alternative";
            }

            if (original.ExperienceTags.Contains(
                    "Culture",
                    StringComparer.OrdinalIgnoreCase) &&
                alternative.ExperienceTags.Contains(
                    "Culture",
                    StringComparer.OrdinalIgnoreCase))
            {
                return "Culture Alternative";
            }

            return "Experience Alternative";
        }

        private static int GetAlternativeTypeScore(
            Destination original,
            Destination alternative)
        {
            string originalType =
                original.DestinationType.ToLowerInvariant();

            string alternativeType =
                alternative.DestinationType.ToLowerInvariant();

            // Strongest match: same destination type.
            if (originalType == alternativeType)
                return 100;

            int matchingTags =
                original.ExperienceTags
                    .Intersect(
                        alternative.ExperienceTags,
                        StringComparer.OrdinalIgnoreCase)
                    .Count();

            if (matchingTags >= 4)
                return 90;

            if (matchingTags >= 3)
                return 80;

            if (matchingTags >= 2)
                return 65;

            if (matchingTags >= 1)
                return 45;

            return 20;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Destination>> GetAll(
            [FromQuery] string? state,
            [FromQuery] string? city,
            [FromQuery] string? category,
            [FromQuery] string? budgetTier)
        {
            var result = Destinations.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(state))
                result = result.Where(d =>
                    d.State.Equals(
                        state,
                        StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(city))
                result = result.Where(d =>
                    d.City.Equals(
                        city,
                        StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(category))
                result = result.Where(d =>
                    d.Category.Equals(
                        category,
                        StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(budgetTier))
                result = result.Where(d =>
                    d.BudgetTier.Equals(
                        budgetTier,
                        StringComparison.OrdinalIgnoreCase));

            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<object> GetById(int id)
        {
            var destination =
                Destinations.FirstOrDefault(d => d.Id == id);

            if (destination == null)
                return NotFound();

            Destination? alternative = null;

            if (destination.AlternativeDestinationId.HasValue)
            {
                alternative = Destinations.FirstOrDefault(
                    d => d.Id == destination.AlternativeDestinationId.Value);
            }

            var predictedCrowd = new List<object>();

            for (int i = 0; i < 3; i++)
            {
                var date = DateTime.Today.AddDays(i);

                predictedCrowd.Add(new
                {
                    Date = date.ToString("yyyy-MM-dd"),
                    DayLabel = i == 0
                        ? "Today"
                        : date.ToString("dddd"),
                    CrowdLevel = PredictCrowdForDate(
                        destination,
                        date)
                });
            }

            return Ok(new
            {
                destination.Id,
                destination.Name,
                destination.Description,
                destination.State,
                destination.City,
                destination.Latitude,
                destination.Longitude,
                destination.Category,
                destination.BudgetTier,
                destination.CrowdLevel,
                destination.DestinationType,
                destination.ExperienceTags,
                destination.ImageUrls,
                destination.VideoUrls,
                destination.Activities,
                destination.StayOptions,
                destination.FoodOptions,
                destination.Guides,
                Alternative = alternative,
                PredictedCrowd = predictedCrowd
            });
        }

        // =========================================================
        // DATE-AWARE + MULTIPLE ALTERNATIVE TYPES
        // =========================================================

        [HttpGet("{id}/recommendations")]
        public ActionResult<object> GetRecommendations(
            int id,
            [FromQuery] double startLatitude,
            [FromQuery] double startLongitude,
            [FromQuery] DateTime? travelDate)
        {
            var destination =
                Destinations.FirstOrDefault(d => d.Id == id);

            if (destination == null)
            {
                return NotFound(new
                {
                    Message = "Destination not found."
                });
            }

            DateTime selectedTravelDate =
                travelDate?.Date ?? DateTime.Today;

            double wantedDistance = CalculateDistanceKm(
                startLatitude,
                startLongitude,
                destination.Latitude,
                destination.Longitude);

            var recommendations = Destinations
                .Where(d => d.Id != destination.Id)
                .Select(d =>
                {
                    double alternativeDistance =
                        CalculateDistanceKm(
                            startLatitude,
                            startLongitude,
                            d.Latitude,
                            d.Longitude);

                    double distanceDifferencePercent =
                        wantedDistance == 0
                            ? 100
                            : Math.Abs(
                                alternativeDistance - wantedDistance)
                              / wantedDistance * 100;

                    int matchingTags =
                        destination.ExperienceTags
                            .Intersect(
                                d.ExperienceTags,
                                StringComparer.OrdinalIgnoreCase)
                            .Count();

                    int totalTags = Math.Max(
                        destination.ExperienceTags.Count,
                        d.ExperienceTags.Count);

                    double experienceMatch =
                        totalTags == 0
                            ? 0
                            : (double)matchingTags
                              / totalTags * 100;

                    // =================================================
                    // FEATURE #5
                    // Date-aware crowd prediction
                    // =================================================

                    string dateAwareCrowdLevel =
                        PredictCrowdForDate(
                            d,
                            selectedTravelDate);

                    int crowdScore =
                        dateAwareCrowdLevel switch
                        {
                            "Low" => 100,
                            "Medium" => 60,
                            "High" => 20,
                            _ => 40
                        };

                    int budgetScore =
                        destination.BudgetTier.Equals(
                            d.BudgetTier,
                            StringComparison.OrdinalIgnoreCase)
                            ? 100
                            : 50;

                    double distanceScore;

                    if (distanceDifferencePercent <= 10)
                        distanceScore = 100;
                    else if (distanceDifferencePercent <= 15)
                        distanceScore = 90;
                    else if (distanceDifferencePercent <= 25)
                        distanceScore = 70;
                    else if (distanceDifferencePercent <= 40)
                        distanceScore = 40;
                    else
                        distanceScore = 0;

                    // =================================================
                    // FEATURE #6
                    // Multiple alternative types
                    // =================================================

                    string alternativeType =
                        GetAlternativeType(
                            destination,
                            d);

                    int alternativeTypeScore =
                        GetAlternativeTypeScore(
                            destination,
                            d);

                    double recommendationScore =
                        (experienceMatch * 0.40) +
                        (crowdScore * 0.20) +
                        (budgetScore * 0.15) +
                        (distanceScore * 0.10) +
                        (alternativeTypeScore * 0.15);

                    return new
                    {
                        Destination = d,

                        AlternativeType =
                            alternativeType,

                        AlternativeTypeScore =
                            alternativeTypeScore,

                        DistanceFromStartKm =
                            Math.Round(
                                alternativeDistance,
                                1),

                        WantedDestinationDistanceKm =
                            Math.Round(
                                wantedDistance,
                                1),

                        DistanceDifferencePercent =
                            Math.Round(
                                distanceDifferencePercent,
                                1),

                        ExperienceMatchPercent =
                            Math.Round(
                                experienceMatch,
                                1),

                        CrowdLevelForTravelDate =
                            dateAwareCrowdLevel,

                        TravelDate =
                            selectedTravelDate.ToString("yyyy-MM-dd"),

                        CrowdScore =
                            crowdScore,

                        BudgetScore =
                            budgetScore,

                        DistanceScore =
                            distanceScore,

                        RecommendationScore =
                            Math.Round(
                                recommendationScore,
                                1),

                        MatchingTags =
                            destination.ExperienceTags
                                .Where(tag =>
                                    d.ExperienceTags.Contains(
                                        tag,
                                        StringComparer.OrdinalIgnoreCase))
                                .ToList()
                    };
                })
                .Where(r => r.DistanceScore > 0)
                .OrderByDescending(
                    r => r.RecommendationScore)
                .Take(5)
                .ToList();

            return Ok(new
            {
                WantedDestination = new
                {
                    destination.Id,
                    destination.Name,
                    destination.DestinationType,
                    destination.CrowdLevel,
                    destination.BudgetTier,

                    DistanceFromStartKm =
                        Math.Round(
                            wantedDistance,
                            1)
                },

                TravelDate =
                    selectedTravelDate.ToString("yyyy-MM-dd"),

                Recommendations =
                    recommendations
            });
        }
    }
}