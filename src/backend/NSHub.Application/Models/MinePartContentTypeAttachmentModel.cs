// <copyright file="MinePartContentTypeAttachmentModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Enums;

namespace NSHub.Application.Models;

public class MinePartContentTypeAttachmentModel
{
	public MinePartContentTypeAttachmentType Type { get; set; }

	public string Url { get; set; } = string.Empty;
}
