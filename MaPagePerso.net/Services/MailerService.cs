using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MaPagePerso.net.Form;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace MaPagePerso.net.Services
{
    public class MailerService
    {
        private readonly string _authUsername;
        private readonly string _authPassword;
        private readonly MimeMessage _message;

        public MailerService(IConfiguration configuration, MimeMessage message)
        {
            _message = message;

#if DEBUG
            _authUsername = configuration.GetSection("Mailer").GetSection("Username").Value;
            _authPassword = configuration.GetSection("Mailer").GetSection("Password").Value;
#elif RELEASE
            _authUsername = Environment.GetEnvironmentVariable("MAILER_USERNAME");
            _authPassword = Environment.GetEnvironmentVariable("MAILER_PASSWORD");
#endif

            _message.From.Add(MailboxAddress.Parse("florian@rampin.me"));
            _message.To.Add(MailboxAddress.Parse("florian@rampin.me"));
        }

        public async Task SendContact(Mailer mailer)
        {
            _message.Subject = $"cv.rampin.me - Nouveau contact de : {mailer.Username}";

#if DEBUG
            _message.Subject = "#DEBUG - " + _message.Subject;
#endif

            _message.Body = new TextPart("plain")
            {
                Text = $@"Username : {mailer.Username}
Email : {mailer.Mail}

Contenu du message :
{mailer.Content}"
            };

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.gmail.com", 465, true);

            await client.AuthenticateAsync(
                _authUsername,
                _authPassword
            );

            await client.SendAsync(_message);

            await client.DisconnectAsync(true);
        }
    }
}