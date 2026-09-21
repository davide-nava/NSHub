// <copyright file="PaymentTerm.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class PaymentTerm    : BaseEntityType
{
   

    public Guid Days { get; set; }

    public bool EndOfMonth { get; set; }

 
}
