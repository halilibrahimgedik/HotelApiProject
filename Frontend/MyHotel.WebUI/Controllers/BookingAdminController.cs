using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
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
        private readonly IBookingService _bookingService;

        public BookingAdminController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IBookingService bookingService)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _bookingService = bookingService;
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

        public IActionResult ApproveStatus(int id)
        {
            _bookingService.TChangeStatusToApprovedWithId(id);


            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:5120/api/reservation/"+id);

            //if (responseMessage.IsSuccessStatusCode)
            //{

            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var stringData = JsonConvert.DeserializeObject<ListBookingsDto>(jsonData);
            //    if (stringData != null)
            //    {
            //        stringData.Status = "Onaylandı";
            //        jsonData = JsonConvert.SerializeObject(stringData);
            //        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //        await client.PutAsync("http://localhost:5120/api/reservation/", stringContent);
            //    }

            //    return RedirectToAction("Index");
            //}

            return RedirectToAction("Index");
        }
    }
}
