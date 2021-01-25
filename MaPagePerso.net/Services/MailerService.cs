﻿using System.Threading.Tasks;
using Core.Flash;
using MailKit.Net.Smtp;
using MaPagePerso.net.Form;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace MaPagePerso.net.Services
{
    public class MailerService
    {
        private readonly IFlasher _flasher;
        private readonly string _authUsername;
        private readonly string _authPassword;
        private readonly MimeMessage _message;

        public MailerService(IConfiguration configuration, IFlasher flasher, MimeMessage message)
        {
            _flasher = flasher;
            _message = message;

            _authUsername = configuration.GetSection("Mailer").GetSection("Username").Value;
            _authPassword = configuration.GetSection("Mailer").GetSection("Password").Value;

            _message.From.Add(MailboxAddress.Parse("contact@florianrampin.fr"));
            _message.To.Add(MailboxAddress.Parse("contact@florianrampin.fr"));
        }

        public async Task SendContact(Mailer mailer)
        {
            _message.Subject = $"FlorianRampin.fr - Nouveau contact de : {mailer.Username}";
            
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
            _flasher.Flash("success", "Votre message a bien été envoyé !", dismissable: true);

            await client.DisconnectAsync(true);
        }
    }
}