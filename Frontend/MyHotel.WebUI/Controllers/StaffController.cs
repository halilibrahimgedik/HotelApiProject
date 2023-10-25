using Microsoft.AspNetCore.Mvc;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.Models.Staff;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace MyHotel.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public StaffController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;

        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_configuration.GetValue<string>("ApiClient") + "/staff");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_configuration.GetValue<string>("ApiClient") + "/staff", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:5120/api/staff?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5120/api/staff/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(data);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5120/api/Staff", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
