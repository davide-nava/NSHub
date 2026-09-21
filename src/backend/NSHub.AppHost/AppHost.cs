// <copyright file="AppHost.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

#pragma warning disable MA0048
var builder = DistributedApplication.CreateBuilder(args);
#pragma warning restore MA0048

builder.AddProject<Projects.NSHub_Api>("nshub-api");
await builder.Build().RunAsync();
