using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace EmailSender.Services
{
    public class AppEmailService
    {
        public async Task SendMail(IFormFile file, string info)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Hack",
                "datojanjalia@gmail.com");

            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User",
                "djanj13@freeuni.edu.ge");
            message.To.Add(to);

            message.Subject = "Hack Registration";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<h1>{info}</h1>";
            bodyBuilder.TextBody = info;

            await using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                bodyBuilder.Attachments.Add(file.FileName, memoryStream.ToArray());
            }

            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("datojanjalia@gmail.com", "Pizmati1");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
