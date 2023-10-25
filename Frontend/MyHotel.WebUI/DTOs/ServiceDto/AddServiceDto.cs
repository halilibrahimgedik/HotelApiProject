using System.ComponentModel.DataAnnotations;

namespace MyHotel.WebUI.DTOs.ServiceDto
{
    public class AddServiceDto
    {
        [Required(ErrorMessage ="Hizmet ikonu giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(50,ErrorMessage ="Hizmet başlığı max 100 karakter olabilir")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
