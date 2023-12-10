using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.WebUI.DTOs.ContactDto;
using MyHotel.WebUI.DTOs.SendMessageDto;
using MyHotel.WebUI.Models.Staff;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public AdminContactController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync(configuration.GetValue<String>("ApiClient") + "/contact");

            if(responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var messages = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                return View(messages);
            }

            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            var client = httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync(configuration.GetValue<String>("ApiClient") + "/SendMessage");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var messages = JsonConvert.DeserializeObject<List<SendBoxDto>>(jsonData);

                return View(messages);
            }

            return View();
        }


        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderName = "admin";
            model.SenderMail = "admin@gmail.com";

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(configuration.GetValue<string>("ApiClient") + "/SendMessage", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }

            return View();
        }


        public async Task<IActionResult> SendBoxMessageDetails(int id=0)
        {
            var client = httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync(configuration.GetValue<string>("ApiClient")+"/SendMessage/"+id);
            
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<ReadMessageDetailDto>(jsonData);

                return View(datas);
            }

            return View();
        }

        public async Task<IActionResult> InboxMessageDetails(int id = 0)
        {
            var client = httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync(configuration.GetValue<string>("ApiClient") + "/contact/" + id);

            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);

                return View(datas);
            }

            return View();
        }


        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
    }
}
