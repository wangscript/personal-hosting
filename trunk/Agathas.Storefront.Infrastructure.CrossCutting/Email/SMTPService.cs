using System.Net.Mail;

namespace Agathas.Storefront.Infrastructure.CrossCutting.Email
{
    public class SmtpService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            var message = new MailMessage { Subject = subject, Body = body };

            var smtp = new SmtpClient();

            smtp.Send(message);
        }
    }
}
