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
using NSHub.Domain.Enums;

namespace NSHub.Infrastructure.Services;

public class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    public string GenerateToken(Employee employee, string role)
    {
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
            new("lang", employee.PreferredLanguage.ToLocaleCode()),
            new("regime", ((int)employee.Oll1Regime).ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateUserToken(NSHub.Domain.Identity.Entities.User user, IEnumerable<string> roles)
    {
        var secret = configuration["Jwt:Secret"] ?? "OpenX_Enterprise_Super_Secret_Key_For_Swiss_TimeTracking_2026_Minimum_32_Bytes!";
        var issuer = configuration["Jwt:Issuer"] ?? "OpenXGest";
        var audience = configuration["Jwt:Audience"] ?? "OpenXGestClient";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
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
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
