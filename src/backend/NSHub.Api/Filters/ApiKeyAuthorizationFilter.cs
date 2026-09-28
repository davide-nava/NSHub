// <copyright file="ApiKeyAuthorizationFilter.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NSHub.Api.Validators;
using NSHub.Application.Constants;

namespace NSHub.Api.Filters;

/// <summary>
/// Authorization filter validating incoming requests by verifying the ApiKey header.
/// </summary>
/// <param name="apiKeyValidator">The API key validator service.</param>
public class ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator) : IAuthorizationFilter
{
    /// <summary>
    /// Evaluates authorization requirements by verifying the request API key.
    /// </summary>
    /// <param name="context">The authorization filter context.</param>
    public void OnAuthorization(AuthorizationFilterContext context)
	{
		ArgumentNullException.ThrowIfNull(context);

		var apiKey = context.HttpContext.Request.Headers[HeaderConstant.ApiKey].ToString();

		if (!apiKeyValidator.IsValid(apiKey))
		{
			context.Result = new UnauthorizedResult();
		}
	}
}
