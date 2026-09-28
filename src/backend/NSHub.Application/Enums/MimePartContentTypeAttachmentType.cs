// <copyright file="MimePartContentTypeAttachmentType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Enums;

/// <summary>
/// Defines the supported MIME content type categories for attachments.
/// </summary>
public enum MimePartContentTypeAttachmentType
{
    /// <summary>
    /// Represents plain text content.
    /// </summary>
    Text = 0,

    /// <summary>
    /// Represents image content.
    /// </summary>
    Image = 1,

    /// <summary>
    /// Represents application-specific content, such as PDF documents,
    /// Microsoft Office files, or other binary attachments.
    /// </summary>
    Application = 2,
}
