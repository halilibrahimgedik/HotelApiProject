using FluentValidation;
using MyHotel.EntityLayer.Concrete;
using MyHotel.WebUI.DTOs.GuestDto;

namespace MyHotel.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            RuleFor(x => x.Name).MaximumLength(25).WithMessage("En fazla 25 karakter giriniz.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            RuleFor(x => x.Surname).MaximumLength(25).WithMessage("En fazla 25 karakter giriniz.");

            RuleFor(x => x.GuestIdentityNo).NotEmpty().WithMessage("TC alanı boş geçilemez.");
            RuleFor(x => x.GuestIdentityNo).Length(11).WithMessage("TC alanı '11' karakter olmalıdır.");

            RuleFor(x => x.Age).NotEmpty().WithMessage("Yaş alanı boş geçilemez.");
            RuleFor(x => x.Age).InclusiveBetween(1, 255).WithMessage("Lütfen uygun bir yaş giriniz");
            
        }
    }
}
