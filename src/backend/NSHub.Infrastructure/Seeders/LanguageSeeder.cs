// <copyright file="LanguageSeeder.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Constants;
using NSHub.Application.Entities;

namespace NSHub.Infrastructure.Seeders;

public static class LanguageSeeder
{
    private static readonly (Guid, string, string)[] data =
    [
        (LanguageConstant.Italian.Id, LanguageConstant.Italian.Description, LanguageConstant.Italian.Name),
        (LanguageConstant.English.Id, LanguageConstant.English.Description, LanguageConstant.English.Name),
        (LanguageConstant.French.Id, LanguageConstant.French.Description, LanguageConstant.French.Name),
        (LanguageConstant.German.Id, LanguageConstant.German.Description, LanguageConstant.German.Name),
    ];

    public static IEnumerable<Language> EnumerateSeeds()
    {
        var list = new List<Language>();

        foreach (var ele in data)
        {
            list.Add(new Language
            {
                Id = ele.Item1,
                Code = ele.Item2,
            });
        }

        return list;
    }
}
