using Microsoft.Extensions.Configuration;
using Portfolio.Models;
using Portfolio.Services.Interfaces;
using System.Net.Mail;
using System.Net;

namespace Portfolio.Services.Repositories
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _smtpClient;
        private readonly string _ownerEmail;
        private readonly string _smtpEmail;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration["SMTPKey"];
            _smtpClient = _configuration["SMTPClient"];
            _smtpEmail = _configuration["SMTPEmail"];
            _ownerEmail = _configuration["OwnerEmail"];
        }

        public async Task<bool> SendEmail(ContactViewModel contactModel)
        {
            bool isSuccess;

            var smtpClient = new SmtpClient(_smtpClient)
            {
                Port = 2525,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = false,
                Credentials = new NetworkCredential(_smtpEmail, _apiKey)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpEmail),
                Subject = "Greetings From Portfolio",
                Body = $"<h1>Hello, I would like to share the following message with you.</h1>" +
                $"<br><p>{contactModel.Message}</p><br>" +
                $"<p>Sincerely, {contactModel.Name}</p>" +
                $"<p>Contact Info: {contactModel.Email}</p>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(_ownerEmail);

          
            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                isSuccess = true;
            }
            catch (Exception)
            {
                isSuccess = false;
            }

            return isSuccess;

        }
    }
}
