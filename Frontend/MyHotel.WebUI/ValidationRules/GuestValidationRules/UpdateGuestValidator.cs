using FluentValidation;
using MyHotel.WebUI.DTOs.GuestDto;

namespace MyHotel.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Ad alanına en az 2 karakter giriniz.")
                .MaximumLength(25).WithMessage("Ad alanına en fazla 25 karakter giriniz.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Soyad alanına En az 2 karakter giriniz.")
                .MaximumLength(25).WithMessage("Soyad alanına En fazla 25 karakter giriniz.");

            RuleFor(x => x.GuestIdentityNo).NotEmpty().WithMessage("TC alanı boş geçilemez.")
                .Length(11).WithMessage("TC alanı '11' karakter olmalıdır.");

            RuleFor(x => x.Age).NotEmpty().WithMessage("Yaş alanı boş geçilemez.")
                .InclusiveBetween(1, 150).WithMessage("Lütfen uygun bir yaş giriniz");
        }
    }
}
