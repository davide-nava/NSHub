// <copyright file="SupplierPriceImport.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities
{
    /// <summary>
    /// Represents supplier pricing import data.
    /// </summary>
    public class SupplierPriceImport
    {
        /// <summary>Gets or sets field 0.</summary>
        public string? Field0 { get; set; }

        /// <summary>Gets or sets price 1.</summary>
        public double? Price1 { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string? Description { get; set; }
    }
