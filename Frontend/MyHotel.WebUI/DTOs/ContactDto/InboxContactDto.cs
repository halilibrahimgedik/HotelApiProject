using MyHotel.EntityLayer.Concrete;

namespace MyHotel.WebUI.DTOs.ContactDto
{
    public class InboxContactDto
    {
        public int ContactId { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string Date { get; set; } = DateTime.Now.ToString();


        public int MessageCategoryId { get; set; }
    }
}
