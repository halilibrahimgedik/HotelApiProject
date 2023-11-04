namespace MyHotel.WebUI.DTOs.BookingDto
{
    public class AddBookingDto
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        public DateTime Checkin { get; set; }

        public DateTime Checkout { get; set; }

        public string AdultCount { get; set; }

        public string ChildrenCount { get; set; }

        public string RoomCount { get; set; }

        public string SpecialRequest { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
