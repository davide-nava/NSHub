// <copyright file="SmtpOption.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Services;

namespace NSHub.Application.Options;

public class SmtpOption
{
    public string Host { get => AesService.Decrypt(field); set; } = null!;

    public int Port { get; set; } = 587;

    public string Security { get; set; } = "Auto";

    public string Username { get => AesService.Decrypt(field); set; } = "xxxx";

    public string Password { get => AesService.Decrypt(field); set; } = "xxxxx";

    public string Sender { get => AesService.Decrypt(field); set; } = "xxxx";

    public string Template { get; set; } = string.Empty;

    public bool Login { get; set; } = true;

    public bool Enable { get; set; } = true;

    public string ReplyTo { get => AesService.Decrypt(field); set; } = "xxxx";

    public string Ticket { get => AesService.Decrypt(field); set; } = "xxx";

    public string Cc { get; set; } = string.Empty;

    public string Bcc { get; set; } = string.Empty;

    public string Dns { get; set; } = "https://localhost";
}
