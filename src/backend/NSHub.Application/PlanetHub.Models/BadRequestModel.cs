// <copyright file="BadRequestModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.PlanetHub.Models;

public record BadRequestModel(string TraceId, List<BadRequestErrorModel> Errors)
{
	public static string Title => "Bad Request";

	public static int Status => 400;
}

