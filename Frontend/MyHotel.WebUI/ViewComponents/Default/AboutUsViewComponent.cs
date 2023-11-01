using Microsoft.AspNetCore.Mvc;
using MyHotel.WebUI.DTOs.AboutDto;
using Newtonsoft.Json;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class AboutUsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AboutUsViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5120/api/about");
            if (responseMessage.IsSuccessStatusCode)
            {
                var stringData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListAboutDto>>(stringData);
                return View(values);
            }
            return View();
        }
    }
}
