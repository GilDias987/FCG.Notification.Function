using FCG.Notification.Func.Dto;
using FCG.Notification.Func.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FCG.Notification.Func.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(EmailMessageDto email)
        {
            var smtpServer = Environment.GetEnvironmentVariable("Server");
            var port = int.Parse(Environment.GetEnvironmentVariable("Port"));
            var user = Environment.GetEnvironmentVariable("User");
            var password = Environment.GetEnvironmentVariable("Password");

            var message = new MailMessage
            {
                From = new MailAddress(user, "FCG Games"),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true
            };

            message.To.Add(email.To);

            using var client = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(user, password),
                EnableSsl = true
            };

            await client.SendMailAsync(message);
        }
    }
}
