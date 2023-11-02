using Microsoft.AspNetCore.Mvc;
using MyHotel.WebUI.DTOs.StaffDto;
using Newtonsoft.Json;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public TeamViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5120/api/Staff");

            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListStaffDto>>(stringData);

                return View(values);
            }

            return View();
        }
    }
}
