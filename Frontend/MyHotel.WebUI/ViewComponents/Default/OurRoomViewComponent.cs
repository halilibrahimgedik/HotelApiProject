using Microsoft.AspNetCore.Mvc;
using MyHotel.BusinessLayer.Abstract;
using MyHotel.WebUI.DTOs.RoomDto;
using Newtonsoft.Json;

namespace MyHotel.WebUI.ViewComponents.Default
{
    public class OurRoomViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory clientFactory;
        public OurRoomViewComponent(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =  clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5120/api/room");

            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListRoomDto>>(stringData);
                return View(values);
            }

            return View();
        }
    }
}
