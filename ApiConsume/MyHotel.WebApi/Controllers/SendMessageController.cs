using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;
        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var sendMessageList = _sendMessageService.TGetAll();
            return Ok(sendMessageList);
        }

        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TAdd(sendMessage);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSendMessage(int id)
        {
            var sendMessage = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(sendMessage);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSentMessage(int id)
        {
            var sentMessage = _sendMessageService.TGetById(id);
            return Ok(sentMessage);
        }
    }
}
