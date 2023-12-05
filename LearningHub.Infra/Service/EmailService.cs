using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;

using LearningHub.Core.Services;
using MailKit.Net.Smtp;
using MimeKit;
namespace LearningHub.Infra.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpHost; // e.g., "smtp.gmail.com"
        private readonly int _smtpPort; // e.g., 587
        private readonly string _fromEmail;
        private readonly string _fromEmailPassword;

        public EmailService(string smtpHost, int smtpPort, string fromEmail, string fromEmailPassword)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _fromEmail = fromEmail;
            _fromEmailPassword = fromEmailPassword;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Traveling", _fromEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpHost, _smtpPort, false);
                await client.AuthenticateAsync(_fromEmail, _fromEmailPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }


        //public async Task SendEmailWithAttachmentAsync(string toEmail, string subject, string body, Stream attachmentStream, string attachmentFileName)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("Traveling", _fromEmail));
        //    message.To.Add(new MailboxAddress("", toEmail));
        //    message.Subject = subject;

        //    var multipart = new Multipart("mixed");

        //    // Text Part (Email Body)
        //    var textPart = new TextPart("plain")
        //    {
        //        Text = body,
        //    };
        //    multipart.Add(textPart);

        //    using (var reader = new StreamReader(attachmentStream))
        //    {
        //        var pdfContent = reader.ReadToEnd();
        //        // Log or print the PDF content to inspect it.
        //        Console.WriteLine("PDF Content:");
        //        Console.WriteLine(pdfContent);
        //        // Reset the stream position.
        //        attachmentStream.Seek(0, SeekOrigin.Begin);
        //    }
        //    // Attachment Part (PDF)
        //    var attachment = new MimePart("application", "pdf")
        //    {
        //        Content = new MimeContent(attachmentStream, ContentEncoding.Default),
        //        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
        //        FileName = attachmentFileName,
        //    };

        //    multipart.Add(attachment);

        //    message.Body = multipart;

        //    using (var client = new SmtpClient())
        //    {
        //        await client.ConnectAsync(_smtpHost, _smtpPort, false);
        //        await client.AuthenticateAsync(_fromEmail, _fromEmailPassword);
        //        await client.SendAsync(message);
        //        await client.DisconnectAsync(true);
        //    }
        //}
    }

    }