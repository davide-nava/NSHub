// <copyright file="Bank.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Bank : AuditableTenantEntity
{
    public string? Name { get; protected set; }
    public string? SwiftBic { get; protected set; }
    public string? Abi { get; protected set; }
    public string? CountryCode { get; protected set; }

    private readonly List<BankAccount> _bankAccounts = new();
    public virtual IReadOnlyCollection<BankAccount> BankAccounts => _bankAccounts.AsReadOnly();

    protected Bank() { }

    public static Bank Create()
    {
        return new Bank();
    }
}
