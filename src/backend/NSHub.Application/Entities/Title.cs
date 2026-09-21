// <copyright file="Title.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Title : BaseEntityType
{


    public Guid TitleTypeId { get; set; }


    public virtual TitleType? TitleType { get; set; }

}
