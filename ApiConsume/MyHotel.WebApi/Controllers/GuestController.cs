using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService guestService;

        public GuestController(IGuestService guestService)
        {
            this.guestService = guestService;
        }

        [HttpGet]
        public IActionResult ListGuest()
        {
            var guests = guestService.TGetAll();

            return Ok(guests);
        }

        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            guestService.TAdd(guest);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGuest(int id)
        {
            var guest = guestService.TGetById(id);
            guestService.TDelete(guest);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            guestService.TUpdate(guest);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var guest = guestService.TGetById(id);

            return Ok(guest);
        }
    }
}
