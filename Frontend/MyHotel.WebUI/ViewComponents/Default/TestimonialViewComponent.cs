using Microsoft.AspNetCore.Mvc;
using MyHotel.WebUI.DTOs.TestimonialDto;
using Newtonsoft.Json;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public TestimonialViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5120/api/testimonial");

            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListTestimonialDto>>(stringData);
                
                return View(values);
            }

            return View();
        }
    }
}
