// <copyright file="JwtTokenService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Service providing JWT token generation for authenticated employees and users.
/// </summary>
public class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    /// <inheritdoc/>
    public string GenerateToken(Employee employee, string role)
    {
        ArgumentNullException.ThrowIfNull(employee);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new(ClaimTypes.Email, employee.Email),
            new(ClaimTypes.GivenName, employee.FirstName),
            new(ClaimTypes.Surname, employee.LastName),
            new(ClaimTypes.Role, role),
            new("tenant_id", employee.TenantId?.ToString() ?? Guid.Empty.ToString()),
        };

        return BuildToken(claims);
    }

    /// <inheritdoc/>
    public string GenerateUserToken(User user, IEnumerable<string> roles)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(roles);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new("aspnet_user_id", user.AspNetUserId),
            new("tenant_id", user.CurrentTenantId?.ToString() ?? Guid.Empty.ToString()),
        };

        if (!string.IsNullOrEmpty(user.Email))
        {
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
        }

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return BuildToken(claims);
    }

    private string BuildToken(IEnumerable<Claim> claims)
    {
        var secret = configuration["Jwt:Secret"] ?? "NSHubDefaultSuperSecretKeyForDevelopmentAndTesting123456!";
        var issuer = configuration["Jwt:Issuer"] ?? "NSHub";
        var audience = configuration["Jwt:Audience"] ?? "NSHub";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
