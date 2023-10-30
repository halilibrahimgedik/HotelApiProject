using System.ComponentModel.DataAnnotations;

namespace MyHotel.WebUI.DTOs.RegisterDto
{
    public class AddNewUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Şifreniz 'Password' alanı ile uyuşmuyor")]
        [Required]
        [DataType(DataType.Password)]
        public string Repassword { get; set; }
    }
}
