using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.WebUI.DTOs.ContactDto;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

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
