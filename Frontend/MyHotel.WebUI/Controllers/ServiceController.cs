using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.WebUI.DTOs.ServiceDto;
using Newtonsoft.Json;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public ServiceController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;

        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_configuration.GetValue<string>("ApiClient") + "/service");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListServiceDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(AddServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5120/api/service", content);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("http://localhost:5120/api/service?id=" + id);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5120/api/service/" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);

                return View(data);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PutAsync("http://localhost:5120/api/service/", content);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(dto);
        }

    }
}
