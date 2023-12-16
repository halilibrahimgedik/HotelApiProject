using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService messageCategoryService;
        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            this.messageCategoryService = messageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var messageCategoryList = messageCategoryService.TGetAll();
            return Ok(messageCategoryList);
        }

        [HttpPost]
        public IActionResult AddmessageCategory(MessageCategory messageCategory)
        {
            messageCategoryService.TAdd(messageCategory);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletemessageCategory(int id)
        {
            var messageCategory = messageCategoryService.TGetById(id);
            messageCategoryService.TDelete(messageCategory);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatemessageCategory(MessageCategory messageCategory)
        {
            messageCategoryService.TUpdate(messageCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetmessageCategory(int id)
        {
            var messageCategory = messageCategoryService.TGetById(id);
            return Ok(messageCategory);
        }
    }
}
