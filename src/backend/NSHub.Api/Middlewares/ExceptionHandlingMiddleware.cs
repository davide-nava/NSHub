// <copyright file="ExceptionHandlingMiddleware.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Net;
using System.Text.Json;
using NSHub.Application.Exceptions;

namespace NSHub.Api.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
	public async Task InvokeAsync(HttpContext context)
	{
		ArgumentNullException.ThrowIfNull(context);
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "An unhandled exception occurred.");
			await HandleExceptionAsync(context, ex);
		}
	}

	private async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var response = context.Response;
		response.ContentType = "application/json";

		var statusCode = exception switch
		{
			KeyNotFoundException => HttpStatusCode.NotFound,
			UnauthorizedAccessException => HttpStatusCode.Unauthorized,
			_ => HttpStatusCode.InternalServerError,
		};

		var exceptionType = exception switch
		{
			NSHubForbiddenException => "Forbidden",
			_ => "GenericError",
		};

		var message = exception switch
		{
			NSHubForbiddenException => "Forbidden",
			_ => "GenericError",
		};

		if (message == "GenericError")
#pragma warning disable CA2254 // Template should be a static expression
		{
			logger.LogError(exception, message);
		}
#pragma warning restore CA2254 // Template should be a static expression

		response.StatusCode = (int)statusCode;

		var result = JsonSerializer.Serialize(new { type = exceptionType, error = message });
		await response.WriteAsync(result);
	}
}
