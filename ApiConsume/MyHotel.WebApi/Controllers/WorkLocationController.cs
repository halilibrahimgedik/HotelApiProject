using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var workLocations = _workLocationService.TGetAll();

            return Ok(workLocations);
        }

        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TAdd(workLocation);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteWorkLocation(int id)
        {
            var workLocation = _workLocationService.TGetById(id);
            _workLocationService.TDelete(workLocation);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TUpdate(workLocation);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var workLocation = _workLocationService.TGetById(id);

            return Ok(workLocation);
        }
    }

}
