// <copyright file="CurrencyConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Models;

namespace NSHub.Application.Constants;

public static class CurrencyConstant
{
	public static ConstantValue Chf => new() { Id = new("C8734C8A-5E7D-4DD7-9F66-37BB509DB3C8"), Name = "chf", Index = 1 };

	public static ConstantValue Eur => new() { Id = new("BEAE3795-0821-48D9-97B0-474F23B9858A"), Name = "eur", Index = 2 };

	public static bool CheckId(Guid id) => currencies.Any(e => e.Id == id);

	public static bool CheckName(string name) => currencies.Any(e => e.Name == name);

	public static ConstantValue CheckOrDefaultName(string name) => !CheckName(name) ? Chf : currencies.First(e => e.Name == name);

    public static ConstantValue CheckOrDefaultId(Guid id) => !CheckId(id) ? Chf : currencies.First(e => e.Id == id);

    private static readonly List<ConstantValue> currencies =
[
	Chf,
		Eur,
	];
}
