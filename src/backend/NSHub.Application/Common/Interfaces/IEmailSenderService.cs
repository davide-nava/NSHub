// <copyright file="IEmailSenderService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

using NSHub.Application.Models;

/// <summary>
/// Service contract for sending emails.
/// </summary>
public interface IEmailSenderService
{
    /// <summary>
    /// Sends an email asynchronously.
    /// </summary>
    /// <param name="recipient">The recipient email address(es).</param>
    /// <param name="subject">The email subject.</param>
    /// <param name="body">The email body text or HTML.</param>
    /// <param name="attachments">Optional file attachments.</param>
    /// <param name="cc">Optional CC email address(es).</param>
    /// <param name="bcc">Optional BCC email address(es).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SendEmailAsync(string recipient, string subject, string body, IEnumerable<MinePartContentTypeAttachmentModel>? attachments = null, string cc = "", string bcc = "");
}
