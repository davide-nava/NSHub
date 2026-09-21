// <copyright file="CustomHeaderParameter.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NSHub.Api.OperationFilters;

public class CustomHeaderParameter(bool addTenantId) : IOperationFilter
{
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
