using BookingSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private IBookingRepository bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> Get()
        {
            return Ok(bookingRepository.GetAllBookings());
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id)
        {
            var booking = bookingRepository.GetBooking(id);

            if (booking == null) return NotFound();

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            var result = bookingRepository.CreateBooking(booking);

            if (!result) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]JsonPatchDocument<Booking> bookingPatch)
        {
            var booking = bookingRepository.GetBooking(id);

            if (booking == null) return NotFound();

            bookingPatch.ApplyTo(booking);

            return Ok();
        }
    }
}
