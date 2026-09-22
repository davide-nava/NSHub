// <copyright file="SettingController.cs" company="Progel SA">
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
public class SettingController(ISettingQueryService queryService, ISettingCommandService commandService, IRequestContext requestContext)
    : BaseController<Setting, SettingModel, ISettingQueryService, ISettingCommandService>(queryService, commandService, requestContext);
