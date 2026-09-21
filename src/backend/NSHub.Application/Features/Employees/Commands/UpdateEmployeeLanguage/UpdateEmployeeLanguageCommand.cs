// <copyright file="UpdateEmployeeLanguageCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeLanguage;

/// <summary>
/// Command to update the preferred UI and compliance language of an employee.
/// </summary>
public record UpdateEmployeeLanguageCommand(Guid EmployeeId, LanguageCode Language) : IRequest<Result>;
