// <copyright file="ContentTypeConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Constants;

/// <summary>
/// Defines MIME type constants used throughout the application.
/// </summary>
public static class ContentTypeConstant
{
    /// <summary>
    /// Represents the MIME type for arbitrary binary data.
    /// </summary>
    public const string OCTETSTREAM = "application/octet-stream";

    /// <summary>
    /// Represents the MIME type for Microsoft Excel Open XML documents (.xlsx).
    /// </summary>
    public const string XLSX = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    /// <summary>
    /// Represents the MIME type for Microsoft Word Open XML documents (.docx).
    /// </summary>
    public const string DOCX = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

    /// <summary>
    /// Represents the MIME type for PDF documents.
    /// </summary>
    public const string PDF = "application/pdf";

    /// <summary>
    /// Represents the MIME type for JSON content.
    /// </summary>
    public const string JSON = "application/json";
}
