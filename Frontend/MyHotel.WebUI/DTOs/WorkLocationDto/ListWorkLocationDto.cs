using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebUI.DTOs.WorkLocationDto
{
    public class ListWorkLocationDto
    {
        public int WorkLocationId { get; set; }

        public string WorkLocationName { get; set; }

        public string WorkLocationCity { get; set; }
    }
}
