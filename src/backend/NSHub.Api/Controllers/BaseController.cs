// <copyright file="BaseController.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces;
using NSHub.ApplicationCore.Interfaces.Services.Commands;
using NSHub.ApplicationCore.Interfaces.Services.Queries;
using NSHub.Constants;
using NSHub.Enums;
using NSHub.Models;
using NSHub.Models.EntityModels;

namespace NSHub.Api.Controllers;

[ApiController]
[Authorize]
public class BaseController<TEntity, TModel, TQueryService, TCommandService>(TQueryService queryService, TCommandService commandService, IRequestContext requestContext) : ControllerBase
    where TEntity : BaseEntity
    where TModel : BaseEntityModel
    where TQueryService : IBaseQueryService<TEntity, TModel>
    where TCommandService : IBaseCommandService<TEntity, TModel>
{
    [HttpGet]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> List(int? pageNumber, int? pageSize, string? sortingBy, SortingDirectionType sortingDirectionType = SortingDirectionType.Desc)
    {
        var pagination = new PaginationModel() { PageNumber = pageNumber, PageSize = pageSize, SortingBy = sortingBy, SortingDirectionType = sortingDirectionType };

        var models = await queryService.ListModelAsync(requestContext.UserId, requestContext.TenantId, pagination);

        return Ok(models);
    }

    [HttpPost]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] TModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (model.Id == Guid.Empty)
        {
            model.Id = Guid.NewGuid();
        }

        model = await commandService.CreateByModelAsync(model, requestContext.UserId, requestContext.TenantId);

        return await Get(model.Id);
    }

    [HttpGet("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var model = await queryService.GetModelAsync(id, requestContext.UserId, requestContext.TenantId);
        if (model == null)
        {
            return NotFound();
        }

        return Ok(model);
    }

    [HttpPut("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, [FromBody] TModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        if (id != model.Id)
        {
            return BadRequest();
        }

        var entity = await queryService.GetAsync(id, requestContext.UserId, requestContext.TenantId);
        if (entity == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await commandService.UpdateByModelAsync(model, requestContext.UserId, requestContext.TenantId);

        return await Get(model.Id);
    }

    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var entity = await queryService.GetAsync(id, requestContext.UserId, requestContext.TenantId);
        if (entity == null)
        {
            return NotFound();
        }

        await commandService.DeleteAsync(id, requestContext.UserId, requestContext.TenantId);

        return NoContent();
    }

    [HttpGet("lookup")]
    [ProducesResponseType<List<LookupModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Lookup() => Ok(await queryService.LookupAsync(requestContext.UserId, requestContext.TenantId));

    [HttpGet("count")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Count()
    {
        var count = await queryService.CountAsync(requestContext.UserId, requestContext.TenantId);

        return Ok(count);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [NonAction]
    protected void AddModelError(string key, ValidationErrorType error) => ModelState.AddModelError(key, error.ToString());

    [ApiExplorerSettings(IgnoreApi = true)]
    [NonAction]
    public override BadRequestObjectResult BadRequest([ActionResultObjectValue] ModelStateDictionary modelState)
    {
        ArgumentNullException.ThrowIfNull(modelState);

        return new BadRequestObjectResult(
            new BadRequestModel(
                HttpContext.TraceIdentifier,
                [
                    .. modelState
                        .SelectMany(q => q.Value!.Errors.Select(e => (q.Key, Value: e.ErrorMessage)))
                        .Select(q => new BadRequestErrorModel(q.Key, q.Value))
                ]));
    }

    [NonAction]
    [ApiExplorerSettings(IgnoreApi = true)]
    protected string GetRequestLanguage()
    {
        var languageCode = Request.Headers.AcceptLanguage.ToString();

        if (string.IsNullOrWhiteSpace(languageCode))
        {
            return LanguageConstant.Italian.Name;
        }

        if (languageCode.Contains('_'))
        {
            languageCode = languageCode.Split('_')[0].Trim();
        }

        languageCode = languageCode[0].ToString().ToUpperInvariant() + languageCode[1..].ToLowerInvariant();

        return LanguageConstant.CheckOrDefaultName(languageCode).Name;
    }
}
