// <copyright file="TitleType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class TitleType : BaseEntityType
{


    public virtual ICollection<Title> Titles { get; set; } = [];

}
