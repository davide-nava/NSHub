// <copyright file="BadRequestErrorModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.PlanetHub.Models;

public record BadRequestErrorModel(string Field, string ErrorCode);

