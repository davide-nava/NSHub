// <copyright file="LogType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class LogType : BaseEntityType
{

    public virtual ICollection<Log> Logs { get; set; } = [];

}
