// <copyright file="WebFileHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace NSHub.Application.Helpers;

public static class WebFileHelper
{
    public static async Task DownloadFileAsync(IEnumerable<byte> data, string? fileName, IJSRuntime js, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(logger);

        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation("Download file {FileName}", fileName);
        }

        if (data.Any())
        {
            await js.InvokeVoidAsync("downloadFileFromStream", fileName ?? "NSHub", data.ToArray());
        }
    }
}
