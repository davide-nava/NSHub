// <copyright file="CustomHeaderParameter.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NSHub.Api.OperationFilters;

/// <summary>
/// Swagger operation filter appending custom headers (such as TenantId) to OpenAPI documentation.
/// </summary>
/// <param name="addTenantId">A value indicating whether the TenantId header should be appended.</param>
public class CustomHeaderParameter(bool addTenantId) : IOperationFilter
{
    /// <summary>
    /// Applies header definitions to the Swagger/OpenAPI operation.
    /// </summary>
    /// <param name="operation">The OpenAPI operation.</param>
    /// <param name="context">The operation filter context.</param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
		ArgumentNullException.ThrowIfNull(operation);
		var listParameters = operation.Parameters;

		if (addTenantId)
		{
			listParameters?.Add(new OpenApiParameter
			{
				Name = "TenantId",
				In = ParameterLocation.Header,
				Description = "Tenant Id",
				Required = true,
				AllowEmptyValue = false,
			});
		}

		operation.Parameters = listParameters;
	}
}
