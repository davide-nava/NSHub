// <copyright file="EmailSenderService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Models;
using NSHub.Application.Options;

namespace NSHub.Application.Services;

public class EmailSenderService(IOptionsMonitor<SmtpOption> smtpOption, ILogger<EmailSenderService> logger) : IEmailSenderService
{
    public async Task SendEmailAsync(string recipient, string subject, string body, IEnumerable<MinePartContentTypeAttachmentModel>? attachments = null, string cc = "", string bcc = "")
    {
        if (smtpOption.CurrentValue.Enable)
        {
            using var client = await CreateClientAsync();

            if (client != null)
            {
                using var message = CreateMessage(subject, recipient, smtpOption.CurrentValue.Sender, cc: cc, bcc: bcc);

                BodyBuilder builder = new() { HtmlBody = await GetBodyTextAsync(body) };

                builder = CreateBuilder(attachments, builder);

                message.Body = builder.ToMessageBody();
                _ = await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }

    private static BodyBuilder CreateBuilder(IEnumerable<MinePartContentTypeAttachmentModel>? attachments, BodyBuilder builder)
    {
        if (attachments != null && ((List<MinePartContentTypeAttachmentModel>)attachments).Count > 0)
        {
            foreach (var attachment in from MinePartContentTypeAttachmentModel ele in attachments.ToList()
                                       where !string.IsNullOrWhiteSpace(ele.Url)
                                       let tmpType = Enum.GetName(ele.Type)?.ToUpperInvariant() ?? string.Empty
                                       let flInfo = new FileInfo(ele.Url)
                                       select new MimePart(tmpType, flInfo.Extension.Replace(".", string.Empty, StringComparison.InvariantCulture).ToUpperInvariant())
                                       {
                                           Content = new MimeContent(File.OpenRead(ele.Url), ContentEncoding.Default),
                                           ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                                           ContentTransferEncoding = ContentEncoding.Base64,
                                           FileName = flInfo.Name,
                                       })
            {
                builder.Attachments.Add(attachment);
            }
        }

        return builder;
    }

    private static IEnumerable<InternetAddress> GetEmails(InternetAddressList list, string email)
    {
        list ??= [];

        if (email.Contains(';', StringComparison.InvariantCulture))
        {
            foreach (var ele in email.Split(";"))
            {
                list.Add(MailboxAddress.Parse(ele));
            }
        }
        else if (!string.IsNullOrWhiteSpace(email))
        {
            list.Add(MailboxAddress.Parse(email));
        }

        return list.Distinct();
    }

    private async Task<string> GetBodyTextAsync(string text, string templateUrl = "email.html")
    {
        var tmpText = string.IsNullOrWhiteSpace(templateUrl) || templateUrl == "email.html"
            ? await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "email.html"))
            : await File.ReadAllTextAsync(templateUrl);
        return tmpText.Replace("###EmailContent###", text, StringComparison.InvariantCulture)
            .Replace("###EmailDns###", smtpOption.CurrentValue.Dns, StringComparison.InvariantCulture);
    }

    private async Task<MailKit.Net.Smtp.SmtpClient> CreateClientAsync()
    {
        MailKit.Net.Smtp.SmtpClient client = new();
        try
        {
            client.CheckCertificateRevocation = true;

            await client.ConnectAsync(smtpOption.CurrentValue.Host, smtpOption.CurrentValue.Port, MailKit.Security.SecureSocketOptions.Auto);

            if (smtpOption.CurrentValue.Login)
            {
                await client.AuthenticateAsync(smtpOption.CurrentValue.Username, smtpOption.CurrentValue.Password);
            }
        }
        catch (MailKit.Security.SslHandshakeException ex)
        {
            logger.LogError(ex, "SSL handshake error creating client");

            client.CheckCertificateRevocation = false;

            if (!client.IsConnected)
            {
                await client.ConnectAsync(smtpOption.CurrentValue.Host, smtpOption.CurrentValue.Port, MailKit.Security.SecureSocketOptions.Auto);
            }

            if (smtpOption.CurrentValue.Login)
            {
                await client.AuthenticateAsync(smtpOption.CurrentValue.Username, smtpOption.CurrentValue.Password);
            }
        }
        catch (MailKit.CommandException ex)
        {
            logger.LogError(ex, "SMTP command error creating client");
        }
        catch (IOException ex)
        {
            logger.LogError(ex, "IO error creating client");
        }
        catch (System.Net.Sockets.SocketException ex)
        {
            logger.LogError(ex, "Socket error creating client");
        }

        return client;
    }

    private MimeMessage CreateMessage(string subject = "", string recipient = "", string from = "", string replyTo = "", string cc = "", string bcc = "")
    {
        MimeMessage message = new();

        if (!string.IsNullOrEmpty(recipient))
        {
            message.To.AddRange(from InternetAddress item in GetEmails(message.To, recipient)
                                where !message.To.Contains(item)
                                select item);
        }
        else
        {
            message.To.AddRange(from InternetAddress item in GetEmails(message.To, smtpOption.CurrentValue.Ticket)
                                where !message.To.Contains(item)
                                select item);
        }

        if (!string.IsNullOrEmpty(from))
        {
            message.From.AddRange(from InternetAddress item in GetEmails(message.From, @from)
                                  where !message.From.Contains(item)
                                  select item);
        }
        else
        {
            message.From.AddRange(from InternetAddress item in GetEmails(message.From, smtpOption.CurrentValue.Sender)
                                  where !message.From.Contains(item)
                                  select item);
        }

        if (!string.IsNullOrEmpty(replyTo))
        {
            message.ReplyTo.AddRange(from InternetAddress item in GetEmails(message.ReplyTo, replyTo)
                                     where !message.ReplyTo.Contains(item)
                                     select item);
        }
        else
        {
            message.ReplyTo.AddRange(from InternetAddress item in GetEmails(message.ReplyTo, smtpOption.CurrentValue.ReplyTo)
                                     where !message.ReplyTo.Contains(item)
                                     select item);
        }

        if (!string.IsNullOrEmpty(cc))
        {
            message.Cc.AddRange(from InternetAddress item in GetEmails(message.Cc, cc)
                                where !message.Cc.Contains(item)
                                select item);
        }
        else
        {
            message.Cc.AddRange(from InternetAddress item in GetEmails(message.Cc, smtpOption.CurrentValue.Cc)
                                where !message.Cc.Contains(item)
                                select item);
        }

        if (!string.IsNullOrEmpty(bcc))
        {
            message.Bcc.AddRange(from InternetAddress item in GetEmails(message.Bcc, bcc)
                                 where !message.Bcc.Contains(item)
                                 select item);
        }
        else
        {
            message.Bcc.AddRange(from InternetAddress item in GetEmails(message.Bcc, smtpOption.CurrentValue.Bcc)
                                 where !message.Bcc.Contains(item)
                                 select item);
        }

        message.Subject = subject;

        return message;
    }
}
