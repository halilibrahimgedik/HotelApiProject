using Microsoft.AspNetCore.Mvc;
using MyHotel.WebUI.DTOs.BookingDto;
using MyHotel.WebUI.DTOs.ContactDto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(AddContactDto dto)
        {
            // name alanlarını düzeltelim
            if (!string.IsNullOrEmpty(dto.Name))
            {
                string fullName = dto.Name;
                string[] nameParts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < nameParts.Length; i++)
                {
                    nameParts[i] = char.ToUpper(nameParts[i][0]) + nameParts[i].Substring(1);
                }
                dto.Name = string.Join(" ", nameParts);
            }

            //dto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5120/api/contact", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
