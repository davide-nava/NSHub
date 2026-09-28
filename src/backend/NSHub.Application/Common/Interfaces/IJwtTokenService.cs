// <copyright file="IJwtTokenService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Application.Common.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(Employee employee, string role);
    string GenerateUserToken(User user, IEnumerable<string> roles);
}

