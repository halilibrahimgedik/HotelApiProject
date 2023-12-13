using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHotel.WebUI.DTOs.SubscribeDto;
using Newtonsoft.Json;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SubscribePartial(AddSubscriberDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json"); 
            var response = await client.PostAsync("http://localhost:5120/api/subscribe",content);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return PartialView();
        }
    }
}
