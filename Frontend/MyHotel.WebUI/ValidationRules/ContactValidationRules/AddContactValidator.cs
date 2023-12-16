using FluentValidation;
using MyHotel.WebUI.DTOs.ContactDto;
using System.Xml.Linq;

namespace MyHotel.WebUI.ValidationRules.ContactValidationRules
{
    public class AddContactValidator : AbstractValidator<AddContactDto>
    {
        public AddContactValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen 'Ad' alanını boş bırakmayınız.");
            RuleFor(x => x.Mail).NotNull().NotEmpty().WithMessage("Lütfen 'Mail' alanını boş bırakmayınız.");
            RuleFor(x => x.Subject).NotNull().WithMessage("Lütfen 'Konu' alanını boş bırakmayınız.");
            RuleFor(x => x.Message).NotNull().WithMessage("Lütfen 'Mesaj' alanını boş bırakmayınız.");
            RuleFor(x => x.MessageCategoryId).NotNull().WithMessage("Lütfen 'Konu Başlığı' alanını boş bırakmayınız.");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage(" 'Ad'  alanına en az 3 karakter girebilirsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage(" 'Konu'  alanına en az 3 karakter girebilirsiniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage(" 'Konu'  alanına en fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage(" 'Mesaj'  alanına en az 3 karakter girebilirsiniz");
            RuleFor(x => x.Message).MinimumLength(500).WithMessage(" 'Mesaj'  alanına en fazla 500 karakter girebilirsiniz");
        }
    }
}
