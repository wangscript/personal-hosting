namespace Agathas.Storefront.Infrastructure.CrossCutting.Email
{
    public interface IEmailService
    {
        void SendMail(string from, string to, string subject, string body);
    }
}
