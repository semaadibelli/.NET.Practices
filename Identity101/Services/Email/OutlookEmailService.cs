﻿using System.Net;
using System.Net.Mail;
using System.Text;
using Identity101.Models.Configuration;
using Identity101.Models.Email;

namespace Identity101.Services.Email;

public class OutlookEmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public OutlookEmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        this.EmailSettings = _configuration.GetSection("OutlookSettings").Get<EmailSettings>();
    }
    public EmailSettings EmailSettings { get; }

    public Task SendMailAsync(MailModel model)
    {
        var mail = new MailMessage { From = new MailAddress(this.EmailSettings.SenderMail) };

        foreach (var c in model.To)
        {
            mail.To.Add(new MailAddress(c.Address, c.Name));
        }

        foreach (var cc in model.Cc)
        {
            mail.CC.Add(new MailAddress(cc.Address, cc.Name));
        }

        foreach (var cc in model.Bcc)
        {
            mail.Bcc.Add(new MailAddress(cc.Address, cc.Name));
        }

        if (model.Attachs is { Count: > 0 })
        {
            foreach (var attach in model.Attachs)
            {
                var fileStream = attach as FileStream;
                var info = new FileInfo(fileStream.Name);

                mail.Attachments.Add(new Attachment(attach, info.Name));
            }
        }

        mail.IsBodyHtml = true;
        mail.BodyEncoding = Encoding.UTF8;
        mail.SubjectEncoding = Encoding.UTF8;
        mail.HeadersEncoding = Encoding.UTF8;

        mail.Subject = model.Subject;
        mail.Body = model.Body;

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var smtpClient = new SmtpClient(this.EmailSettings.Smtp, this.EmailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(this.EmailSettings.SenderMail, this.EmailSettings.Password),
            EnableSsl = true
        };
        return smtpClient.SendMailAsync(mail);
    }
}