using Microsoft.AspNetCore.Mvc;
using MyHotel.WebUI.DTOs.BookingDto;
using MyHotel.WebUI.DTOs.ServiceDto;
using Newtonsoft.Json;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public BookingAdminController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;

        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5120/api/reservation");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListBookingsDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
