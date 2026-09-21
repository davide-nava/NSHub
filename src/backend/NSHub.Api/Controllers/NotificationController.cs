// <copyright file="NotificationController.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ReportingServices.Interfaces;

using PlanetHub.ApplicationCore.Interfaces;
using PlanetHub.ApplicationCore.Interfaces.Services.Commands;
using PlanetHub.ApplicationCore.Interfaces.Services.Queries;
using PlanetHub.Models.EntityModels;

namespace PlanetHub.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class NotificationController(INotificationQueryService queryService, INotificationCommandService commandService, IRequestContext requestContext)
    : BaseController<Notification, NotificationModel, INotificationQueryService, INotificationCommandService>(queryService, commandService, requestContext);
