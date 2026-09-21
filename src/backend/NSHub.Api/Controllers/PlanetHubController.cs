// <copyright file="PlanetHubController.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PlanetHub.Endpoints.Api;

namespace PlanetHub.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PlanetHubController(ILogger<PlanetHubController> logger, IHostEnvironment hostEnvironment)
    : ControllerBase
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet("/")]
    public ContentResult Index()
    {
        var html = System.IO.File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "wwwroot", "index.html"));
        return Content(html, "text/html");
    }

    [AllowAnonymous]
    [HttpGet(PlanetHubEndpoint.GetPing)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetPing()
    {
        logger.LogTrace("Ping server for keep alive.");

        return Ok();
    }
}
