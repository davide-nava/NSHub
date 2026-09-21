// <copyright file="DownloadFileModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Constants;

namespace NSHub.Application.Models;

public class DownloadFileModel
{
    public IEnumerable<byte> FileBytes { get; set; } = [];

    public string ContentType { get; set; } = ContentTypeConstant.OctetStreamMimeType;

    public string? FileName { get; set; }
}
