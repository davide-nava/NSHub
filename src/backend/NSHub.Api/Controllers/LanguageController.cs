// <copyright file="LanguageController.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Interfaces;
using PlanetHub.ApplicationCore.Interfaces.Services.Commands;
using PlanetHub.ApplicationCore.Interfaces.Services.Queries;
using PlanetHub.Models.EntityModels;

namespace PlanetHub.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class LanguageController(ILanguageQueryService queryService, ILanguageCommandService commandService, IRequestContext requestContext)
    : BaseController<Language, LanguageModel, ILanguageQueryService, ILanguageCommandService>(queryService, commandService, requestContext);
