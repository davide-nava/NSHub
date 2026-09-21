// <copyright file="DownloadFileResponse.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.NSHub.Models.Responses;

public class DownloadFileResponse
{
	public IEnumerable<byte> FileBytes { get; set; } = [];

	public string? ContentType { get; set; }

	public string? FileName { get; set; }
}
