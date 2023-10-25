using System.ComponentModel.DataAnnotations;

namespace MyHotel.WebUI.DTOs.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Hizmet ikonu giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı max 100 karakter olabilir")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet açıklaması max 500 karakter olabilir")]
        public string Description { get; set; }
    }
}
