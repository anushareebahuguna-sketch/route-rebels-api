using Microsoft.AspNetCore.Mvc;
using RouteRebels.Api.Models;

namespace RouteRebels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrowdController : ControllerBase
    {
        // =========================================================
        // DEMO DESTINATION INTELLIGENCE
        // =========================================================

        private class DestinationCrowdInfo
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public bool Popular { get; set; }
            public int BasePressure { get; set; }
            public string[] ExperienceTags { get; set; } = Array.Empty<string>();
            public int? AlternativeId { get; set; }
        }

        private static readonly List<DestinationCrowdInfo> Destinations =
            new()
            {
                new DestinationCrowdInfo
                {
                    Id = 2,
                    Name = "Jaipur City Palace",
                    Popular = true,
                    BasePressure = 70,
                    ExperienceTags = new[]
                    {
                        "History",
                        "Heritage",
                        "Architecture",
                        "Culture",
                        "Photography"
                    },
                    AlternativeId = 3
                },

                new DestinationCrowdInfo
                {
                    Id = 3,
                    Name = "Bundi",
                    Popular = false,
                    BasePressure = 25,
                    ExperienceTags = new[]
                    {
                        "History",
                        "Heritage",
                        "Architecture",
                        "Culture",
                        "Photography"
                    }
                },

                new DestinationCrowdInfo
                {
                    Id = 4,
                    Name = "India Gate",
                    Popular = true,
                    BasePressure = 70,
                    ExperienceTags = new[]
                    {
                        "History",
                        "Culture",
                        "Photography",
                        "City",
                        "Family"
                    },
                    AlternativeId = 5
                },

                new DestinationCrowdInfo
                {
                    Id = 5,
                    Name = "Hauz Khas Village",
                    Popular = false,
                    BasePressure = 25,
                    ExperienceTags = new[]
                    {
                        "History",
                        "Heritage",
                        "Culture",
                        "Cafe",
                        "Photography"
                    }
                },

                new DestinationCrowdInfo
                {
                    Id = 6,
                    Name = "Baga Beach",
                    Popular = true,
                    BasePressure = 70,
                    ExperienceTags = new[]
                    {
                        "Beach",
                        "Water Sports",
                        "Nightlife",
                        "Sea",
                        "Entertainment"
                    },
                    AlternativeId = 7
                },

                new DestinationCrowdInfo
                {
                    Id = 7,
                    Name = "Palolem Beach",
                    Popular = false,
                    BasePressure = 25,
                    ExperienceTags = new[]
                    {
                        "Beach",
                        "Nature",
                        "Sea",
                        "Relaxation",
                        "Photography"
                    }
                },

                new DestinationCrowdInfo
                {
                    Id = 8,
                    Name = "Alleppey Backwaters",
                    Popular = true,
                    BasePressure = 65,
                    ExperienceTags = new[]
                    {
                        "Nature",
                        "Water",
                        "Scenic",
                        "Relaxation",
                        "Boating"
                    },
                    AlternativeId = 9
                },

                new DestinationCrowdInfo
                {
                    Id = 9,
                    Name = "Munnar Hills",
                    Popular = false,
                    BasePressure = 25,
                    ExperienceTags = new[]
                    {
                        "Mountain",
                        "Nature",
                        "Scenic",
                        "Trekking",
                        "Relaxation"
                    }
                },

                new DestinationCrowdInfo
                {
                    Id = 10,
                    Name = "Mussoorie",
                    Popular = true,
                    BasePressure = 70,
                    ExperienceTags = new[]
                    {
                        "Mountain",
                        "Nature",
                        "Scenic",
                        "Trekking",
                        "Relaxation",
                        "Colonial"
                    },
                    AlternativeId = 11
                },

                new DestinationCrowdInfo
                {
                    Id = 11,
                    Name = "Dhanaulti",
                    Popular = false,
                    BasePressure = 25,
                    ExperienceTags = new[]
                    {
                        "Mountain",
                        "Nature",
                        "Scenic",
                        "Trekking",
                        "Relaxation",
                        "Forest"
                    }
                }
            };

        // =========================================================
        // 1. CROWD FORECAST
        // =========================================================

        [HttpGet("{destinationId}")]
        public ActionResult<IEnumerable<CrowdForecast>> GetForecast(
            int destinationId,
            [FromQuery] int days = 7)
        {
            var destination = Destinations.FirstOrDefault(
                d => d.Id == destinationId);

            if (destination == null)
            {
                return NotFound(
                    "Destination crowd information not found.");
            }

            if (days < 3 || days > 7)
            {
                return BadRequest(
                    "Forecast window must be between 3 and 7 days.");
            }

            var forecasts = new List<CrowdForecast>();

            var today = DateTime.Today;

            for (int i = 0; i < days; i++)
            {
                var date = today.AddDays(i);

                int pressureScore =
                    CalculateCrowdScore(
                        destination,
                        date);

                string crowdLevel =
                    GetCrowdLevel(pressureScore);

                forecasts.Add(
                    new CrowdForecast
                    {
                        Date = date,
                        Day = date.ToString("dddd"),
                        PressureScore = pressureScore,
                        CrowdLevel = crowdLevel,
                        IsRecommendedDay =
                            pressureScore <= 40
                    });
            }

            return Ok(forecasts);
        }

        // =========================================================
        // 2. CROWD DIVERSION ENGINE
        // =========================================================

        [HttpGet("{destinationId}/diversions")]
        public ActionResult GetDiversions(
            int destinationId,
            [FromQuery] DateTime? travelDate = null,
            [FromQuery] string? preferences = null)
        {
            var destination = Destinations.FirstOrDefault(
                d => d.Id == destinationId);

            if (destination == null)
            {
                return NotFound(
                    "Destination not found.");
            }

            DateTime selectedDate =
                travelDate?.Date ?? DateTime.Today;

            List<string> selectedPreferences =
                ParsePreferences(preferences);

            int currentPressure =
                CalculateCrowdScore(
                    destination,
                    selectedDate);

            if (currentPressure < 56)
            {
                return Ok(new
                {
                    destinationId = destination.Id,

                    destinationName =
                        destination.Name,

                    travelDate =
                        selectedDate.ToString("yyyy-MM-dd"),

                    selectedPreferences,

                    currentCrowdPressure =
                        currentPressure,

                    currentCrowdLevel =
                        GetCrowdLevel(
                            currentPressure),

                    needsDiversion = false,

                    message =
                        $"This destination currently has manageable crowd pressure for {selectedDate:dddd, dd MMMM yyyy}.",

                    alternatives =
                        Array.Empty<object>()
                });
            }

            var alternatives =
                Destinations
                    .Where(d =>
                        d.Id != destination.Id)
                    .Select(alternative =>
                    {
                        int alternativePressure =
                            CalculateCrowdScore(
                                alternative,
                                selectedDate);

                        double experienceMatch =
                            CalculateExperienceMatch(
                                destination.ExperienceTags,
                                alternative.ExperienceTags);

                        double crowdReduction =
                            CalculateCrowdReduction(
                                currentPressure,
                                alternativePressure);

                        var preferenceResult =
                            CalculatePreferenceMatch(
                                selectedPreferences,
                                alternative.ExperienceTags);

                        double preferenceMatch =
                            preferenceResult.MatchPercent;

                        string[] matchingPreferences =
                            preferenceResult.MatchingPreferences;

                        double crowdAvoidanceScore =
                            CalculateCrowdAvoidanceScore(
                                experienceMatch,
                                crowdReduction,
                                preferenceMatch,
                                selectedPreferences.Count > 0);

                        return new
                        {
                            id = alternative.Id,

                            name =
                                alternative.Name,

                            crowdPressure =
                                alternativePressure,

                            crowdLevel =
                                GetCrowdLevel(
                                    alternativePressure),

                            experienceMatchPercent =
                                Math.Round(
                                    experienceMatch),

                            crowdReductionPercent =
                                Math.Round(
                                    crowdReduction),

                            crowdAvoidanceScore =
                                Math.Round(
                                    crowdAvoidanceScore),

                            matchingTags =
                                destination.ExperienceTags
                                    .Intersect(
                                        alternative.ExperienceTags,
                                        StringComparer
                                            .OrdinalIgnoreCase)
                                    .ToArray(),

                            preferenceScore =
                                Math.Round(
                                    preferenceMatch),

                            preferenceMatchPercent =
                                Math.Round(
                                    preferenceMatch),

                            matchingPreferences =
                                matchingPreferences
                        };
                    })
                    .Where(a =>
                        a.experienceMatchPercent >= 40 &&
                        a.crowdReductionPercent > 0)
                    .OrderByDescending(
                        a => a.crowdAvoidanceScore)
                    .ThenByDescending(
                        a => a.preferenceMatchPercent)
                    .ToList();

            return Ok(new
            {
                destinationId =
                    destination.Id,

                destinationName =
                    destination.Name,

                travelDate =
                    selectedDate.ToString("yyyy-MM-dd"),

                selectedPreferences,

                currentCrowdPressure =
                    currentPressure,

                currentCrowdLevel =
                    GetCrowdLevel(
                        currentPressure),

                needsDiversion = true,

                message =
                    selectedPreferences.Count > 0
                        ? $"This destination is experiencing high tourism pressure for {selectedDate:dddd, dd MMMM yyyy}. Alternatives have been personalized around your selected experiences."
                        : $"This destination is experiencing high tourism pressure for {selectedDate:dddd, dd MMMM yyyy}. These alternatives can help spread visitor demand.",

                alternatives
            });
        }

        // =========================================================
        // 3. FEATURE #8
        // REBEL ROUTE ITINERARY
        // =========================================================
        //
        // Example:
        //
        // GET:
        // api/Crowd/10/itinerary
        //     ?alternativeId=9
        //     &days=3
        //     &preferences=Nature,Trekking
        //
        // =========================================================

        [HttpGet("{destinationId}/itinerary")]
        public ActionResult GetItinerary(
            int destinationId,
            [FromQuery] int alternativeId,
            [FromQuery] int days = 3,
            [FromQuery] string? preferences = null)
        {
            var originalDestination =
                Destinations.FirstOrDefault(
                    d => d.Id == destinationId);

            if (originalDestination == null)
            {
                return NotFound(
                    "Original destination not found.");
            }

            var alternativeDestination =
                Destinations.FirstOrDefault(
                    d => d.Id == alternativeId);

            if (alternativeDestination == null)
            {
                return NotFound(
                    "Alternative destination not found.");
            }

            if (destinationId == alternativeId)
            {
                return BadRequest(
                    "Original and alternative destinations must be different.");
            }

            if (days < 3 || days > 7)
            {
                return BadRequest(
                    "Itinerary duration must be between 3 and 7 days.");
            }

            List<string> selectedPreferences =
                ParsePreferences(preferences);

            // =====================================================
            // FIND PREFERENCE MATCHES
            // =====================================================

            var preferenceResult =
                CalculatePreferenceMatch(
                    selectedPreferences,
                    alternativeDestination.ExperienceTags);

            // =====================================================
            // BUILD ITINERARY
            // =====================================================

            var itineraryDays =
                new List<object>();

            for (int day = 1; day <= days; day++)
            {
                var dayPlan =
                    BuildItineraryDay(
                        alternativeDestination,
                        selectedPreferences,
                        day,
                        days);

                itineraryDays.Add(dayPlan);
            }

            // =====================================================
            // CROWD INFORMATION
            // =====================================================

            int originalPressure =
                CalculateCrowdScore(
                    originalDestination,
                    DateTime.Today);

            int alternativePressure =
                CalculateCrowdScore(
                    alternativeDestination,
                    DateTime.Today);

            double crowdReduction =
                CalculateCrowdReduction(
                    originalPressure,
                    alternativePressure);

            double experienceMatch =
                CalculateExperienceMatch(
                    originalDestination.ExperienceTags,
                    alternativeDestination.ExperienceTags);

            double crowdAvoidanceScore =
                CalculateCrowdAvoidanceScore(
                    experienceMatch,
                    crowdReduction,
                    preferenceResult.MatchPercent,
                    selectedPreferences.Count > 0);

            // =====================================================
            // RESPONSE
            // =====================================================

            return Ok(new
            {
                originalDestination = new
                {
                    id = originalDestination.Id,
                    name = originalDestination.Name
                },

                alternativeDestination = new
                {
                    id = alternativeDestination.Id,
                    name = alternativeDestination.Name,
                    experienceTags =
                        alternativeDestination.ExperienceTags
                },

                durationDays = days,

                selectedPreferences,

                preferenceMatchPercent =
                    Math.Round(
                        preferenceResult.MatchPercent),

                matchingPreferences =
                    preferenceResult.MatchingPreferences,

                experienceMatchPercent =
                    Math.Round(
                        experienceMatch),

                crowdReductionPercent =
                    Math.Round(
                        crowdReduction),

                crowdAvoidanceScore =
                    Math.Round(
                        crowdAvoidanceScore),

                routeTitle =
                    $"{originalDestination.Name} → {alternativeDestination.Name}",

                routeMessage =
                    selectedPreferences.Count > 0
                        ? $"A {days}-day Rebel Route built around your {string.Join(", ", selectedPreferences)} preferences."
                        : $"A {days}-day lower-pressure route designed to preserve the experience while reducing crowd pressure.",

                itinerary =
                    itineraryDays
            });
        }

        // =========================================================
        // 4. BUILD ITINERARY DAY
        // =========================================================

        private object BuildItineraryDay(
            DestinationCrowdInfo destination,
            List<string> preferences,
            int day,
            int totalDays)
        {
            bool hasTrekking =
                HasPreference(
                    preferences,
                    "trekking") ||
                HasTag(
                    destination.ExperienceTags,
                    "Trekking");

            bool hasNature =
                HasPreference(
                    preferences,
                    "nature") ||
                HasTag(
                    destination.ExperienceTags,
                    "Nature");

            bool hasPhotography =
                HasPreference(
                    preferences,
                    "photography") ||
                HasTag(
                    destination.ExperienceTags,
                    "Photography");

            bool hasCulture =
                HasPreference(
                    preferences,
                    "culture") ||
                HasTag(
                    destination.ExperienceTags,
                    "Culture");

            bool hasHeritage =
                HasPreference(
                    preferences,
                    "heritage") ||
                HasTag(
                    destination.ExperienceTags,
                    "Heritage");

            bool hasBeach =
                HasPreference(
                    preferences,
                    "beach") ||
                HasTag(
                    destination.ExperienceTags,
                    "Beach");

            bool hasRelaxation =
                HasPreference(
                    preferences,
                    "relaxation") ||
                HasTag(
                    destination.ExperienceTags,
                    "Relaxation");

            bool hasFood =
                HasPreference(
                    preferences,
                    "food");

            bool hasNightlife =
                HasPreference(
                    preferences,
                    "nightlife") ||
                HasTag(
                    destination.ExperienceTags,
                    "Nightlife");

            // =====================================================
            // DAY 1
            // =====================================================

            if (day == 1)
            {
                var activities =
                    new List<object>
                    {
                        new
                        {
                            time = "Morning",
                            title = "Arrive & Settle In",
                            description =
                                $"Start your Rebel Route in {destination.Name} and settle into a local stay."
                        }
                    };

                if (hasNature)
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Explore the Local Landscape",
                        description =
                            "Take a relaxed walk through the surrounding natural and scenic areas."
                    });
                }
                else if (hasHeritage || hasCulture)
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Discover Local Culture",
                        description =
                            "Explore the destination through its local history, culture and community."
                    });
                }
                else if (hasBeach)
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Beach Exploration",
                        description =
                            "Explore the coastline and discover quieter stretches away from peak tourist zones."
                    });
                }
                else
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Local Exploration",
                        description =
                            "Take a slow first look at the destination and explore local surroundings."
                    });
                }

                if (hasPhotography)
                {
                    activities.Add(new
                    {
                        time = "Evening",
                        title = "Golden Hour Photography",
                        description =
                            "Find a scenic viewpoint and capture the destination during golden hour."
                    });
                }
                else if (hasRelaxation)
                {
                    activities.Add(new
                    {
                        time = "Evening",
                        title = "Slow Evening",
                        description =
                            "Relax and enjoy the destination at a slower pace."
                    });
                }
                else
                {
                    activities.Add(new
                    {
                        time = "Evening",
                        title = "Local Evening",
                        description =
                            "Enjoy a relaxed evening and discover a local food or community spot."
                    });
                }

                return new
                {
                    day,
                    title = "Arrive & Explore",
                    theme = "Orientation",
                    activities
                };
            }

            // =====================================================
            // DAY 2
            // =====================================================

            if (day == 2)
            {
                var activities =
                    new List<object>();

                if (hasTrekking)
                {
                    activities.Add(new
                    {
                        time = "Morning",
                        title = "Local Trekking Experience",
                        description =
                            $"Take a scenic trekking experience around {destination.Name}, preferably with a local guide."
                    });
                }
                else if (hasNature)
                {
                    activities.Add(new
                    {
                        time = "Morning",
                        title = "Nature Trail",
                        description =
                            "Explore a quieter nature trail and spend time away from concentrated tourist crowds."
                    });
                }
                else if (hasBeach)
                {
                    activities.Add(new
                    {
                        time = "Morning",
                        title = "Coastal Experience",
                        description =
                            "Explore a quieter section of the coast and experience the destination beyond its busiest areas."
                    });
                }
                else
                {
                    activities.Add(new
                    {
                        time = "Morning",
                        title = "Local Experience",
                        description =
                            "Spend the morning experiencing a locally rooted activity."
                    });
                }

                if (hasCulture || hasHeritage)
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Local Culture & Heritage",
                        description =
                            "Discover local traditions, stories, architecture and community life."
                    });
                }
                else if (hasFood)
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Local Food Experience",
                        description =
                            "Try regional food through a local restaurant, market or community-led experience."
                    });
                }
                else
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Explore Beyond the Main Attraction",
                        description =
                            "Visit a less-concentrated area and discover what everyday local life looks like."
                    });
                }

                if (hasPhotography)
                {
                    activities.Add(new
                    {
                        time = "Evening",
                        title = "Scenic Photography Walk",
                        description =
                            "Capture local landscapes, architecture and everyday moments."
                    });
                }
                else if (hasNightlife)
                {
                    activities.Add(new
                    {
                        time = "Evening",
                        title = "Local Nightlife",
                        description =
                            "Experience the local evening scene while supporting independent businesses."
                    });
                }
                else
                {
                    activities.Add(new
                    {
                        time = "Evening",
                        title = "Relax & Recharge",
                        description =
                            "Return to your stay and enjoy a slower evening."
                    });
                }

                return new
                {
                    day,
                    title = "Experience the Destination",
                    theme = "Local Experience",
                    activities
                };
            }

            // =====================================================
            // FINAL DAY
            // =====================================================

            if (day == totalDays)
            {
                var activities =
                    new List<object>();

                if (hasFood)
                {
                    activities.Add(new
                    {
                        time = "Morning",
                        title = "Local Food Experience",
                        description =
                            "Enjoy a regional breakfast or food experience from a local business."
                    });
                }
                else if (hasNature)
                {
                    activities.Add(new
                    {
                        time = "Morning",
                        title = "Final Nature Walk",
                        description =
                            "Take one final peaceful walk through the surrounding landscape."
                    });
                }
                else
                {
                    activities.Add(new
                    {
                        time = "Morning",
                        title = "Slow Morning",
                        description =
                            "Enjoy a relaxed final morning before departure."
                    });
                }

                if (hasCulture || hasHeritage)
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Local Market & Community",
                        description =
                            "Visit local vendors or community spaces and pick up locally made products."
                    });
                }
                else if (hasPhotography)
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Final Photo Stop",
                        description =
                            "Visit one final scenic location and capture your favourite memories."
                    });
                }
                else
                {
                    activities.Add(new
                    {
                        time = "Afternoon",
                        title = "Independent Exploration",
                        description =
                            "Use your final afternoon to explore somewhere that caught your attention."
                    });
                }

                activities.Add(new
                {
                    time = "Evening",
                    title = "Depart with a Smaller Footprint",
                    description =
                        "Complete your Rebel Route by supporting local businesses and leaving the destination with a lighter tourism footprint."
                });

                return new
                {
                    day,
                    title = "Connect & Depart",
                    theme = "Local Impact",
                    activities
                };
            }

            // =====================================================
            // DAYS 3–6
            // =====================================================

            var extendedActivities =
                new List<object>();

            if (hasTrekking && day % 2 == 1)
            {
                extendedActivities.Add(new
                {
                    time = "Morning",
                    title = "Extended Trek",
                    description =
                        "Explore another scenic trail and experience the landscape with fewer crowds."
                });
            }
            else if (hasNature)
            {
                extendedActivities.Add(new
                {
                    time = "Morning",
                    title = "Nature Discovery",
                    description =
                        "Explore another natural area and spend time away from concentrated tourist zones."
                });
            }
            else if (hasHeritage || hasCulture)
            {
                extendedActivities.Add(new
                {
                    time = "Morning",
                    title = "Local Heritage Discovery",
                    description =
                        "Discover another side of the destination through local stories and culture."
                });
            }
            else
            {
                extendedActivities.Add(new
                {
                    time = "Morning",
                    title = "Independent Exploration",
                    description =
                        "Explore the destination at your own pace."
                });
            }

            if (hasPhotography)
            {
                extendedActivities.Add(new
                {
                    time = "Afternoon",
                    title = "Photography & Scenic Exploration",
                    description =
                        "Discover another viewpoint or local area and capture the experience."
                });
            }
            else if (hasFood)
            {
                extendedActivities.Add(new
                {
                    time = "Afternoon",
                    title = "Regional Food Trail",
                    description =
                        "Discover regional flavours through independent local food businesses."
                });
            }
            else
            {
                extendedActivities.Add(new
                {
                    time = "Afternoon",
                    title = "Local Discovery",
                    description =
                        "Spend time exploring an area beyond the main tourist circuit."
                });
            }

            if (hasRelaxation)
            {
                extendedActivities.Add(new
                {
                    time = "Evening",
                    title = "Slow Evening",
                    description =
                        "End the day with a relaxed local experience."
                });
            }
            else
            {
                extendedActivities.Add(new
                {
                    time = "Evening",
                    title = "Local Evening Experience",
                    description =
                        "Enjoy an evening experience while supporting local businesses."
                });
            }

            return new
            {
                day,
                title = $"Discover More of {destination.Name}",
                theme = "Explore",
                activities = extendedActivities
            };
        }

        // =========================================================
        // 5. PREFERENCE HELPERS
        // =========================================================

        private List<string> ParsePreferences(
            string? preferences)
        {
            if (string.IsNullOrWhiteSpace(preferences))
            {
                return new List<string>();
            }

            return preferences
                .Split(
                    ',',
                    StringSplitOptions.RemoveEmptyEntries |
                    StringSplitOptions.TrimEntries)
                .Where(p =>
                    !string.IsNullOrWhiteSpace(p))
                .Distinct(
                    StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private string NormalizePreference(
            string value)
        {
            string normalized =
                value.Trim()
                    .ToLowerInvariant();

            return normalized switch
            {
                "mountains" => "mountain",
                "mountain" => "mountain",

                "nature" => "nature",

                "heritage" => "heritage",

                "history" => "heritage",

                "beach" => "beach",

                "trekking" => "trekking",

                "photography" => "photography",

                "culture" => "culture",

                "relaxation" => "relaxation",

                "food" => "food",

                "nightlife" => "nightlife",

                _ => normalized
            };
        }

        private bool HasPreference(
            List<string> preferences,
            string preference)
        {
            string normalized =
                NormalizePreference(
                    preference);

            return preferences.Any(
                p =>
                    NormalizePreference(p) ==
                    normalized);
        }

        private bool HasTag(
            string[] tags,
            string tag)
        {
            return tags.Any(
                t =>
                    string.Equals(
                        NormalizePreference(t),
                        NormalizePreference(tag),
                        StringComparison.OrdinalIgnoreCase));
        }

        private (
            double MatchPercent,
            string[] MatchingPreferences
        ) CalculatePreferenceMatch(
            List<string> selectedPreferences,
            string[] alternativeTags)
        {
            if (selectedPreferences.Count == 0)
            {
                return (
                    0,
                    Array.Empty<string>());
            }

            var matchingPreferences =
                selectedPreferences
                    .Where(preference =>
                    {
                        string normalizedPreference =
                            NormalizePreference(
                                preference);

                        return alternativeTags.Any(tag =>
                            NormalizePreference(tag) ==
                            normalizedPreference);
                    })
                    .ToArray();

            double matchPercent =
                (double)matchingPreferences.Length /
                selectedPreferences.Count *
                100;

            return (
                matchPercent,
                matchingPreferences);
        }

        // =========================================================
        // 6. CROWD SCORE
        // =========================================================

        private int CalculateCrowdScore(
            DestinationCrowdInfo destination,
            DateTime date)
        {
            int score =
                destination.BasePressure;

            if (date.DayOfWeek == DayOfWeek.Friday)
            {
                score += 8;
            }

            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday)
            {
                score += 15;
            }

            return Math.Clamp(
                score,
                0,
                100);
        }

        // =========================================================
        // 7. CROWD LEVEL
        // =========================================================

        private string GetCrowdLevel(
            int pressureScore)
        {
            if (pressureScore <= 30)
            {
                return "Low";
            }

            if (pressureScore <= 55)
            {
                return "Medium";
            }

            if (pressureScore <= 75)
            {
                return "High";
            }

            return "Very High";
        }

        // =========================================================
        // 8. EXPERIENCE MATCH
        // =========================================================

        private double CalculateExperienceMatch(
            string[] originalTags,
            string[] alternativeTags)
        {
            if (originalTags.Length == 0)
            {
                return 0;
            }

            int matchingTags =
                originalTags
                    .Intersect(
                        alternativeTags,
                        StringComparer.OrdinalIgnoreCase)
                    .Count();

            return
                (double)matchingTags /
                originalTags.Length *
                100;
        }

        // =========================================================
        // 9. CROWD REDUCTION
        // =========================================================

        private double CalculateCrowdReduction(
            int originalPressure,
            int alternativePressure)
        {
            if (originalPressure <= 0)
            {
                return 0;
            }

            return
                (double)(
                    originalPressure -
                    alternativePressure
                )
                / originalPressure
                * 100;
        }

        // =========================================================
        // 10. CROWD AVOIDANCE SCORE
        // =========================================================

        private double CalculateCrowdAvoidanceScore(
            double experienceMatch,
            double crowdReduction,
            double preferenceMatch,
            bool hasPreferences)
        {
            double score;

            if (!hasPreferences)
            {
                score =
                    (experienceMatch * 0.45) +
                    (crowdReduction * 0.55);
            }
            else
            {
                score =
                    (experienceMatch * 0.30) +
                    (crowdReduction * 0.40) +
                    (preferenceMatch * 0.30);
            }

            return Math.Clamp(
                score,
                0,
                100);
        }
    }
}