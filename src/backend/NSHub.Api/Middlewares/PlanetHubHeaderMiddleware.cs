// <copyright file="PlanetHubHeaderMiddleware.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Constants;

namespace NSHub.Api.Middlewares;

public class NSHubHeaderMiddleware(RequestDelegate next, ILogger<NSHubHeaderMiddleware> logger, bool useTenantId = false, bool useUserId = false, bool useApiKey = false)
{
	public async Task InvokeAsync(HttpContext context)
	{
		ArgumentNullException.ThrowIfNull(context);
		context.Response.OnStarting(() =>
		{
			if (context.Request.Path.Value?.StartsWith("/api/", StringComparison.OrdinalIgnoreCase) ?? false)
			{
				var validHeader = true;

				//if (useApplicationId)
				//{
				//	if (!context.Request.Headers.ContainsKey(HeaderConstant.ApplicationId))
				//	{
				//		context.Response.StatusCode = StatusCodes.Status400BadRequest;
				//		if (logger.IsEnabled(LogLevel.Error))
				//		{
				//			logger.LogError("Request rejected due to missing {Header} header.", HeaderConstant.ApplicationId);
				//		}

				//		return Task.CompletedTask;
				//	}

				//	try
				//	{
				//		var applicationId = context.Request.Headers[HeaderConstant.ApplicationId].ToString();

				//		validHeader = ApplicationConstant.CheckId(new Guid(applicationId));
				//	}
				//	catch (Exception ex)
				//	{
				//		validHeader = false;
				//		if (logger.IsEnabled(LogLevel.Error))
				//		{
				//			logger.LogError(ex, "Request rejected due to invalid {Header} header.", HeaderConstant.ApplicationId);
				//		}
				//	}
				//}

				if (useTenantId)
				{
					if (!context.Request.Headers.TryGetValue(HeaderConstant.TenantId, out var value))
					{
						context.Response.StatusCode = StatusCodes.Status400BadRequest;
						if (logger.IsEnabled(LogLevel.Error))
						{
							logger.LogError("Request rejected due to missing {Header} header.", HeaderConstant.TenantId);
						}

						return Task.CompletedTask;
					}

					try
					{
						var tenantId = value.ToString();

						validHeader = validHeader && TenantConstant.CheckId(new Guid(tenantId));
					}
					catch (Exception ex)
					{
						validHeader = false;
						if (logger.IsEnabled(LogLevel.Error))
						{
							logger.LogError(ex, "Request rejected due to invalid {Header} header.", HeaderConstant.TenantId);
						}
					}
				}

				if (useUserId)
				{
					if (!context.Request.Headers.TryGetValue(HeaderConstant.UserId, out var value))
					{
						context.Response.StatusCode = StatusCodes.Status400BadRequest;
						if (logger.IsEnabled(LogLevel.Error))
						{
							logger.LogError("Request rejected due to missing {Header} header.", HeaderConstant.UserId);
						}

						return Task.CompletedTask;
					}

					try
					{
						var userId = value.ToString();

						_ = new Guid(userId);
					}
					catch (Exception ex)
					{
						validHeader = false;
						if (logger.IsEnabled(LogLevel.Error))
						{
							logger.LogError(ex, "Request rejected due to missing {Header} header.", HeaderConstant.LanguageId);
						}
					}
				}

				if (useApiKey)
				{
					if (!context.Request.Headers.TryGetValue(HeaderConstant.ApiKey, out var value))
					{
						context.Response.StatusCode = StatusCodes.Status400BadRequest;
						if (logger.IsEnabled(LogLevel.Error))
						{
							logger.LogError("Request rejected due to missing {Header} header.", HeaderConstant.ApiKey);
						}

						return Task.CompletedTask;
					}

					try
					{
						var apiKey = value.ToString();

						if ((string.IsNullOrWhiteSpace(apiKey) || apiKey?.Length < 2000) && logger.IsEnabled(LogLevel.Error))
						{
							logger.LogError("Request rejected due to invalid ApiKey {ApiKey}.", apiKey);
						}
					}
					catch (Exception ex)
					{
						validHeader = false;
						if (logger.IsEnabled(LogLevel.Error))
						{
							logger.LogError(ex, "Request rejected due to missing {Header} header.", HeaderConstant.LanguageId);
						}
					}
				}

				if (!validHeader)
				{
					context.Response.StatusCode = StatusCodes.Status400BadRequest;
					if (logger.IsEnabled(LogLevel.Error))
					{
						logger.LogError("Request rejected due to invalid {Header} header.", HeaderConstant.ApplicationId);
					}

					return Task.CompletedTask;
				}
			}

			return Task.CompletedTask;
		});

		await next(context);
	}
}
