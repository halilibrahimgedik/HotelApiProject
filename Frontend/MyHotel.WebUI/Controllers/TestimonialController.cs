using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.Models.Testimonial;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace MyHotel.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public TestimonialController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<ActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetValue<string>("ApiClient") + "/Testimonial"}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(datas);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5120/api/Testimonial", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("http://localhost:5120/api/Testimonial?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5120/api/Testimonial/" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonData);

                return View(data);
            }

            return View();
        }

        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(JsonData,Encoding.UTF8,"application/json");
            var response = await client.PutAsync("http://localhost:5120/api/Testimonial?id=" + model.TestimonialId,content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
