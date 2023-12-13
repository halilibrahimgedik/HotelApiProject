using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.BookingDto;
using Newtonsoft.Json;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingDto dto)
        {
            // name alanlarını düzeltelim
            string fullName = dto.Name; 
            string[] nameParts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < nameParts.Length; i++)
            {
                nameParts[i] = char.ToUpper(nameParts[i][0]) + nameParts[i].Substring(1);
            }

            dto.Name = string.Join(" ", nameParts);

            dto.Status = "Onay Bekliyor";

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5120/api/reservation", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
