// <copyright file="UserEndpoint.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

namespace PlanetHub.Endpoints.Api;

public static class UserEndpoint
{
    public const string Delete = "/api/user/{id}";

    public const string Update = "/api/user/{id}";

    public const string Read = "/api/user/{id}";

    public const string Create = "/api/user";

    public const string List = "/api/user";

    public const string Lookup = "/api/user/lookup";

    public const string GetUserLogged = "/api/user/logged";

    public const string GetUserConfiguration = "/api/user/configuration";

    public const string PostUserConfiguration = "/api/user/configuration";
}
