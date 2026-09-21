// <copyright file="IApiKeyValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Api.Validators;

public interface IApiKeyValidator
{
    bool IsValid(string apiKey);
}
