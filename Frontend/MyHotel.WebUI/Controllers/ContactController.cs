using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.BookingDto;
using MyHotel.WebUI.DTOs.ContactDto;
using MyHotel.WebUI.DTOs.MessageCategoryDto;
using MyHotel.WebUI.Models.Staff;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5120/api/messageCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListMessageCategoryDto>>(jsonData);

                if (values != null)
                {
                    ViewBag.MessageCategories = new SelectList(values, "MessageCategoryId", "MessageCategoryName");

                    return View();
                }
            }

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

            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(dto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5120/api/contact", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("/Views/ErrorPage/Error404.cshtml","hatalı form gönderimi");

        }
    }
}
