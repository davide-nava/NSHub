// <copyright file="INSHubClient.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace NSHub.Application.Interfaces;

public interface INSHubClient
{
    Task<T> GetAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string uri, CancellationToken cancellationToken);

    Task<T> GetAsync<T>([StringSyntax(StringSyntaxAttribute.Uri)] string uri, Dictionary<string, object?> queryParameters, CancellationToken cancellationToken);

    Task PostAsync<TRequest>([StringSyntax(StringSyntaxAttribute.Uri)] string uri, TRequest request, CancellationToken cancellationToken);

    Task<TResponse> PostAsync<TRequest, TResponse>([StringSyntax(StringSyntaxAttribute.Uri)] string uri, TRequest request, CancellationToken cancellationToken);

    Task PutAsync<TRequest>(string uri, TRequest request, CancellationToken cancellationToken);

    Task DeleteAsync(string uri, CancellationToken cancellationToken);

    Task SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);

    Task<T> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken);
}
