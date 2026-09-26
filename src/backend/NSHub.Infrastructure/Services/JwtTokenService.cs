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
/// Service responsible for generating JSON Web Tokens (JWT) for employees and users.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="JwtTokenService"/> class.
/// </remarks>
/// <param name="configuration">The application configuration providing JWT settings.</param>
public class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    /// <inheritdoc/>
    public string GenerateToken(Employee employee, string role)
    {
        ArgumentNullException.ThrowIfNull(employee);
        ArgumentException.ThrowIfNullOrEmpty(role);

        var secret = configuration["Jwt:Secret"] ?? "OpenX_Enterprise_Super_Secret_Key_For_Swiss_TimeTracking_2026_Minimum_32_Bytes!";
        var issuer = configuration["Jwt:Issuer"] ?? "OpenXGest";
        var audience = configuration["Jwt:Audience"] ?? "OpenXGestClient";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, employee.Email),
            new(ClaimTypes.Name, $"{employee.FirstName} {employee.LastName}"),
            new(ClaimTypes.Role, role),
            new("lang", employee.PreferredLanguage.ToString().ToLowerInvariant()),
            new("regime", ((int)employee.Oll1Regime).ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <inheritdoc/>
    public string GenerateUserToken(User user, IEnumerable<string> roles)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(roles);

        var secret = configuration["Jwt:Secret"] ?? "OpenX_Enterprise_Super_Secret_Key_For_Swiss_TimeTracking_2026_Minimum_32_Bytes!";
        var issuer = configuration["Jwt:Issuer"] ?? "OpenXGest";
        var audience = configuration["Jwt:Audience"] ?? "OpenXGestClient";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(ClaimTypes.Name, user.Email ?? user.Id.ToString()),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
