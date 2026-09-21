// <copyright file="JsonHelpers.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.IO.Compression;
using System.Text.Json;

namespace NSHub.Infrastructure.Helpers;

public static class JsonHelpers
{
    public static async Task<List<T>?> ReadListFromZipFileAsync<T>(string fileZip, string fileJson)
        where T : class
    {
        await using var archive = await ZipFile.OpenReadAsync(fileZip);
        var jsonString = string.Empty;

        foreach (var entry in archive.Entries)
        {
            if (entry.FullName == fileJson)
            {
                using StreamReader reader = new(await entry.OpenAsync());
                jsonString = await reader.ReadToEndAsync();
            }
        }

        return string.IsNullOrWhiteSpace(jsonString) ? null : JsonSerializer.Deserialize<List<T>>(jsonString);
    }

    public static void ClearDestinationFolder(string folder)
    {
        if (!Directory.Exists(folder))
        {
            _ = Directory.CreateDirectory(folder);
        }
        else
        {
            Directory.Delete(folder, true);
            _ = Directory.CreateDirectory(folder);
        }
    }

    public static void CreateZipFileFromFolderAndDeleteFolder(string folder, string fileZip)
    {
        ZipFile.CreateFromDirectory(folder, fileZip);

        if (Directory.Exists(folder))
        {
            Directory.Delete(folder, true);
        }
    }
}
