using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    public EmailSender(IOptions<MailKitEmailSenderOptions> options)
    {
        this.Options = options.Value;
    }

    public MailKitEmailSenderOptions Options { get; set; }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        return Execute(email, subject, message);
    }

    public Task Execute(string to, string subject, string message)
    {
        var email = new MimeMessage
        {
            Sender = MailboxAddress.Parse(Options.SenderEmail)
        };
        if (!string.IsNullOrEmpty(Options.SenderName))
            email.Sender.Name = Options.SenderName;
        email.From.Add(email.Sender);
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = message };

        // send email
        using (var smtp = new SmtpClient())
        {
            smtp.Connect(Options.HostAddress, Options.HostPort);
            smtp.Authenticate(Options.HostUsername, Options.HostPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        return Task.FromResult(true);
    }
}
   