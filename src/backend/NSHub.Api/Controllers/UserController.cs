// <copyright file="UserController.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Entities.Json;
using NSHub.ApplicationCore.Interfaces;
using NSHub.ApplicationCore.Interfaces.Services.Commands;
using NSHub.ApplicationCore.Interfaces.Services.Queries;
using NSHub.Endpoints.Api;
using NSHub.Models;
using NSHub.Models.EntityModels;

namespace NSHub.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController(IUserQueryService queryService, IUserCommandService commandService, IRequestContext requestContext, ILogger<UserController> logger, IUserQueryService userQueryService, SignInManager<ApplicationUser> signInManager, IUserCommandService userCommandService)
    : BaseController<User, UserModel, IUserQueryService, IUserCommandService>(queryService, commandService, requestContext)
{
    [HttpGet(UserEndpoint.GetUserLogged)]
    [ProducesResponseType<UserModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserLoggedAsync()
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation("Get user logged");
        }

        var user = await userQueryService.GetUserLoggedAsync(requestContext.UserId, requestContext.TenantId);
        if (!(user?.IsActive ?? false))
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Return {Return} ", "Unauthorized");
            }

            await signInManager.SignOutAsync();
        }

        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
        }

        return Ok(user);
    }

    [HttpPost(UserEndpoint.PostUserConfiguration)]
    [ProducesResponseType<UserConfigurationJson>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostUserConfigurationAsync(UserConfigurationJson model)
    {
        ArgumentNullException.ThrowIfNull(model);

        logger.LogInformation("Post configurazione");

        var result = await userCommandService.SetConfigurationAsync(model, requestContext.UserId);

        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
        }

        return Ok(result);
    }

    [HttpGet(UserEndpoint.GetUserConfiguration)]
    [ProducesResponseType<UserConfigurationJson>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserConfigurationAsync()
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation("Get configurazione");
        }

        var result = await userQueryService.GetUserConfigurationAsync(requestContext.UserId, requestContext.TenantId);

        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
        }

        return Ok(result);
    }
}
