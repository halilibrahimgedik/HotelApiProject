using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        public readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }


        [HttpGet]
        public IActionResult AboutList()
        {
            var list = aboutService.TGetAll();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            aboutService.TAdd(about);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id) 
        {
            var about = aboutService.TGetById(id);
            if(about == null) { return NotFound(); }
            aboutService.TDelete(about);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAbout(About about) 
        {
            aboutService.TUpdate(about);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id) 
        {
            var about = aboutService.TGetById(id);
            return Ok(about);
        }
    }
}
