// <copyright file="ISoftDeletable.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Interfaces;

public interface ISoftDeletable
{
	bool IsDeleted { get; set; }

	DateTime? DateDeleted { get; set; }
}
