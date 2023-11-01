using Microsoft.AspNetCore.Mvc;
using MyHotel.WebUI.DTOs.ServiceDto;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ServiceViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5120/api/service");

            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListServiceDto>>(stringData);

                return View(values);
            }

            return View();
        }
    }
}
