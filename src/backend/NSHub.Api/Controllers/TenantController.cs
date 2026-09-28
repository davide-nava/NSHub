// <copyright file="TenantController.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces;
using NSHub.ApplicationCore.Interfaces.Services.Commands;
using NSHub.ApplicationCore.Interfaces.Services.Queries;
using NSHub.Models.EntityModels;

namespace NSHub.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TenantController(ITenantQueryService queryService, ITenantCommandService commandService, IRequestContext requestContext)
    : BaseController<Tenant, TenantModel, ITenantQueryService, ITenantCommandService>(queryService, commandService, requestContext);
