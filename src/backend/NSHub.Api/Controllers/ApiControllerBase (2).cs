// <copyright file="ApiControllerBase (2).cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NSHub.Application.Common.Models;

namespace NSHub.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _sender;

    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected ActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
        {
            return NoContent();
        }

        return BadRequest(new ProblemDetails
        {
            Title = "Bad Request",
            Detail = result.Error,
            Status = 400
        });
    }

    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (result.Value is null)
                return NotFound();

            return Ok(result.Value);
        }

        return BadRequest(new ProblemDetails
        {
            Title = "Bad Request",
            Detail = result.Error,
            Status = 400
        });
    }
}
