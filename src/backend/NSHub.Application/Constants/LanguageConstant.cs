// <copyright file="LanguageConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.NSHub.Models;

namespace NSHub.Application.Constants;

public static class LanguageConstant
{
	public static ConstantValue English => new() { Id = new("C7FAF0BA-F47C-4FBB-B41E-9E09ECD33AB9"), Name = "en", Index = 1 };

	public static ConstantValue Italian => new() { Id = new("691AA257-E222-4CA0-92D3-7EB3638D4838"), Name = "it", Index = 2 };

	public static ConstantValue French => new() { Id = new("0EC310AF-6488-4ED8-A863-6ADF4A078EBF"), Name = "fr", Index = 3 };

	public static ConstantValue German => new() { Id = new("7C0EF1F3-ED01-4CFE-89B2-092D30FA6C05"), Name = "de", Index = 4 };

	public static bool CheckId(Guid id) => languages.Any(e => e.Id == id);

	public static bool CheckName(string name) => languages.Any(e => e.Name == name);

	public static ConstantValue CheckOrDefaultName(string name)
	{
		if (!CheckName(name))
		{
			return Italian;
		}

		return languages.First(e => e.Name == name);
	}

	public static ConstantValue CheckOrDefaultId(Guid id)
	{
		if (!CheckId(id))
		{
			return Italian;
		}

		return languages.First(e => e.Id == id);
	}

	private static readonly List<ConstantValue> languages =
[
	English,
		Italian,
		French,
		German,
	];
}

