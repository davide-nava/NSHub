// <copyright file="SmtpOption.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Options;

/// <summary>
/// Represents the SMTP configuration settings used for sending emails.
/// </summary>
public class SmtpOption
{
    /// <summary>
    /// Gets or sets the SMTP server host name.
    /// </summary>
    public string Host { get; set; } = null!;

    /// <summary>
    /// Gets or sets the SMTP server port.
    /// </summary>
    public int Port { get; set; } = 587;

    /// <summary>
    /// Gets or sets the SMTP security mode.
    /// </summary>
    public string Security { get; set; } = "Auto";

    /// <summary>
    /// Gets or sets the username used to authenticate with the SMTP server.
    /// </summary>
    public string Username { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the password used to authenticate with the SMTP server.
    /// </summary>
    public string Password { get; set; } = "xxxxx";

    /// <summary>
    /// Gets or sets the sender email address.
    /// </summary>
    public string Sender { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the path to the email template.
    /// </summary>
    public string Template { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether SMTP authentication is required.
    /// </summary>
    public bool Login { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether SMTP email delivery is enabled.
    /// </summary>
    public bool Enable { get; set; } = true;

    /// <summary>
    /// Gets or sets the reply-to email address.
    /// </summary>
    public string ReplyTo { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the email address used for ticket notifications.
    /// </summary>
    public string Ticket { get; set; } = "xxx";

    /// <summary>
    /// Gets or sets the default carbon copy (CC) recipients.
    /// </summary>
    public string Cc { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the default blind carbon copy (BCC) recipients.
    /// </summary>
    public string Bcc { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the base URL used by the application when generating links in emails.
    /// </summary>
    public string Dns { get; set; } = "https://localhost";
}
