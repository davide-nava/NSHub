// <copyright file="ITimeEntryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Features.TimeTracking.Repositories;

/// <summary>
/// Time entry repository contract alias for the TimeTracking feature slice.
/// </summary>
public interface ITimeEntryRepository : NSHub.Application.Features.TimeAttendance.Repositories.ITimeEntryRepository
{
}
