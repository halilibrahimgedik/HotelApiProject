using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomservice;
        public RoomController(IRoomService roomservice)
        {
            this.roomservice = roomservice;
        }


        [HttpGet]
        public IActionResult ListRoom()
        {
            var rooms = roomservice.TGetAll();

            return Ok(rooms);
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            roomservice.TAdd(room);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var room = roomservice.TGetById(id);
            roomservice.TDelete(room);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room) 
        {
            roomservice.TUpdate(room);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var room = roomservice.TGetById(id);

            return Ok(room);
        }
    }
}
