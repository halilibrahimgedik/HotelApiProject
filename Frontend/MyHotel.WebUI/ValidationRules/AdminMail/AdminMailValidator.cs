using FluentValidation;
using MyHotel.WebUI.Models.Mail;

namespace MyHotel.WebUI.ValidationRules.AdminMail
{
    public class AdminMailValidator : AbstractValidator<AdminMailViewModel>
    {
        public AdminMailValidator()
        {
            RuleFor(x => x.RecieverMail).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.RecieverMail).NotNull().WithMessage("Bu alan boş geçilemez");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Bu alan en az 3 karakter uzunluunda olmalıdır");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Bu alan en az 10 karakter uzunluunda olmalıdır");
        }
    }
}
