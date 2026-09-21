// <copyright file="ITimeEntryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Repository abstraction for managing TimeEntry aggregates.
/// </summary>
public interface ITimeEntryRepository : NSHub.Domain.TimeAttendance.Repositories.ITimeEntryRepository
{
}
