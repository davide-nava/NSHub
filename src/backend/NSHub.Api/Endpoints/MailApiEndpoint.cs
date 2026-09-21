// <copyright file="MailApiEndpoint.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

namespace PlanetHub.Endpoints.Api;

public static class MailApiEndpoint
{
    public const string ConfigurationBase = "/api/mail";

    public const string GetMailList = ConfigurationBase;

    public const string GetMailGet = ConfigurationBase + "/{id}";

    public const string GetMailEventList = ConfigurationBase + "/{mailId}/event";

    public const string GetMailExportList = ConfigurationBase + "/export";
    public const string GetMailHtmlGet = ConfigurationBase + "/{mailId}/html";
}
