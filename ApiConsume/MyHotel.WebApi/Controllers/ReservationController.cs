using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IBookingService bookingService;
        public ReservationController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var bookingList = bookingService.TGetAll();
            return Ok(bookingList);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            bookingService.TAdd(booking);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var booking = bookingService.TGetById(id);
            bookingService.TDelete(booking);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = bookingService.TGetById(id);
            return Ok(booking);
        }
    }
}
