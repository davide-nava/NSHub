// <copyright file="ApiKeyAuthorizationFilter.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NSHub.Api.Validators;
using NSHub.Application.Constants;

namespace NSHub.Api.Filters;

public class ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator) : IAuthorizationFilter
{
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
