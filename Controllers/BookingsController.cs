using Microsoft.AspNetCore.Mvc;
using RouteRebels.Api.Models;

namespace RouteRebels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private static readonly List<Booking> Bookings = new();
        private static int nextId = 1;

        [HttpPost]
        public ActionResult<Booking> CreateBooking([FromBody] Booking booking)
        {
            booking.Id = nextId++;
            booking.BookedAt = DateTime.Now;
            Bookings.Add(booking);
            return Ok(booking);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAll()
        {
            return Ok(Bookings);
        }
    }
}