// <copyright file="JsonHelpers.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.IO.Compression;
using System.Text.Json;

namespace NSHub.Infrastructure.Helpers;

/// <summary>
/// Utility helper methods for handling JSON files and ZIP archives.
/// </summary>
public static class JsonHelpers
{
    /// <summary>
    /// Reads and deserializes a list of items from a specified JSON entry inside a ZIP archive.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    /// <param name="fileZip">The path to the ZIP archive.</param>
    /// <param name="fileJson">The name of the JSON entry within the archive.</param>
    /// <returns>A task representing the asynchronous operation with the deserialized list, or <see langword="null"/> if not found.</returns>
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

    /// <summary>
    /// Clears the destination folder by deleting and recreating it if it exists.
    /// </summary>
    /// <param name="folder">The folder path to clear.</param>
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

    /// <summary>
    /// Creates a ZIP archive from the contents of a directory and deletes the original directory.
    /// </summary>
    /// <param name="folder">The source directory path.</param>
    /// <param name="fileZip">The destination ZIP file path.</param>
    public static void CreateZipFileFromFolderAndDeleteFolder(string folder, string fileZip)
    {
        ZipFile.CreateFromDirectory(folder, fileZip);

        if (Directory.Exists(folder))
        {
            Directory.Delete(folder, true);
        }
    }
}
