using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }


        [HttpGet]
        public IActionResult ContactList()
        {
            var list = contactService.TGetAll();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contactService.TAdd(contact);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = contactService.TGetById(id);
            if (contact == null) { return NotFound(); }
            contactService.TDelete(contact);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            contactService.TUpdate(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = contactService.TGetById(id);
            return Ok(contact);
        }
    }
}
