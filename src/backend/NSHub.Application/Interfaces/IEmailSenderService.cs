// <copyright file="IEmailSenderService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Models;

namespace NSHub.Application.Interfaces;

public interface IEmailSenderService
{
	Task<Task> SendEmailAsync(string recipient, string subject, string body, IEnumerable<MinePartContentTypeAttachmentModel>? attachments = null, string cc = "", string bcc = "");
}
