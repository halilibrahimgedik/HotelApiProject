namespace MyHotel.WebUI.DTOs.GuestDto
{
    public class UpdateGuestDto
    {
        public int GuestId { get; set; }

        public string GuestIdentityNo { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public byte Age { get; set; }
    }
}
