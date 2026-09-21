// <copyright file="AddressType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class AddressType : BaseEntityType
{


    public virtual ICollection<Address> Addresses { get; set; } = [];


}
