using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MyHotel.WebUI.Models.Mail;

namespace MyHotel.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            if(ModelState.IsValid)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "halilgedik4234@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.RecieverMail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = model.Content;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = model.Subject;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("halilgedik4234@gmail.com", "jgxv oevj udyy mlbs");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);

                ModelState.AddModelError("all", "Mesajınız gönderilmiştir");

                return View();
            }

            ModelState.AddModelError("all", "Bir hata oluştu");
            return View();
        }

    }
}
