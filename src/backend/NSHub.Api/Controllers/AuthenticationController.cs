// <copyright file="AuthenticationController.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using System.Net;
using System.Text;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

using NSHub.Endpoints.Api;
using NSHub.Exceptions;
using NSHub.Localization;
using NSHub.Models;
using NSHub.Models.Requests;
using NSHub.Models.Responses;

namespace NSHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthenticationController(ILogger<AuthenticationController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserStore<ApplicationUser> userStore) : ControllerBase
{
    [HttpGet(AuthenticationEndpoint.GetEmailStore)]
    [ProducesResponseType<IUserPasswordStore<ApplicationUser>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public Task<IActionResult> GetUserPasswordStoreAsync() => Task.FromResult<IActionResult>(Ok((IUserPasswordStore<ApplicationUser>)userStore));

    [HttpPost(AuthenticationEndpoint.PostGetByClaimsPrincipal)]
    [ProducesResponseType<ApplicationUser>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostGetByClaimsPrincipalAsync(GetByClaimsPrincipalRequest model)
    {
        var user = await userManager.GetUserAsync(model.ClaimsPrincipal);

        return Ok(user);
    }

    [HttpPost(AuthenticationEndpoint.PostSetUserNameUserStore)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostSetUserNameUserStoreAsync(SetUserNameUserStoreRequest model)
    {
        await ((IUserEmailStore<ApplicationUser>)userStore).SetUserNameAsync(model.User, model.UserName, CancellationToken.None);

        return Ok();
    }

    [HttpPost(AuthenticationEndpoint.PostSetEmailUserStore)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostSetEmailUserStoreAsync(SetEmailUserStoreRequest model)
    {
        await ((IUserEmailStore<ApplicationUser>)userStore).SetEmailAsync(model.User, model.Email, CancellationToken.None);

        return Ok();
    }

    [HttpPost(AuthenticationEndpoint.PostSetEmail)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostSetEmailAsync(SetEmailRequest model) => Ok(await userManager.SetUserNameAsync(model.User, model.Email));

    [HttpGet(AuthenticationEndpoint.GetEmailStore)]
    [ProducesResponseType<IUserEmailStore<ApplicationUser>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public Task<IActionResult> GetEmailStoreAsync()
    {
        if (!userManager.SupportsUserEmail)
        {
            throw new NotSupportedException(SharedResource.TheDefaultUIRequiresAUserStoreWithEmailSupport);
        }

        return Task.FromResult<IActionResult>(Ok((IUserEmailStore<ApplicationUser>)userStore));
    }

    [HttpGet(AuthenticationEndpoint.GetRequireConfirmedAccount)]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public Task<IActionResult> GetRequireConfirmedAccountAsync() => Task.FromResult<IActionResult>(Ok(userManager.Options.SignIn.RequireConfirmedAccount));

    [HttpGet(AuthenticationEndpoint.GetSupportsUserEmail)]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public Task<IActionResult> GetSupportsUserEmailAsync() => Task.FromResult<IActionResult>(Ok(userManager.SupportsUserEmail));

    [HttpGet(AuthenticationEndpoint.GetAuthenticatorTokenProvider)]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public Task<IActionResult> GetAuthenticatorTokenProviderAsync() => Task.FromResult<IActionResult>(Ok(userManager.Options.Tokens.AuthenticatorTokenProvider));

    [HttpPost(AuthenticationEndpoint.PostVerifyTwoFactorToken)]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostVerifyTwoFactorTokenAsync(VerifyTwoFactorTokenRequest model) => Ok(await userManager.VerifyTwoFactorTokenAsync(model.User, model.TokenProvider, model.Token));

    [HttpPost(AuthenticationEndpoint.PostRemoveLogin)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostRemoveLoginAsync(RemoveLoginRequest model) => Ok(await userManager.RemoveLoginAsync(model.User, model.LoginProvider, model.ProviderKey));

    [HttpPost(AuthenticationEndpoint.PostResetAuthenticatorKey)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostResetAuthenticatorKeyAsync(ResetAuthenticatorKeyRequest model) => Ok(await userManager.ResetAuthenticatorKeyAsync(model.User));

    [HttpPost(AuthenticationEndpoint.PostExternalLoginSignIn)]
    [ProducesResponseType<Microsoft.AspNetCore.Identity.SignInResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostExternalLoginSignInAsync(ExternalLoginSignInRequest model) => Ok(await signInManager.ExternalLoginSignInAsync(model.LoginProvider, model.ProviderKey, model.IsPersistent));

    [HttpPost(AuthenticationEndpoint.PostMakePasskeyRequestOptions)]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostMakePasskeyRequestOptionsAsync(MakePasskeyRequestOptionsRequest model) => Ok(await signInManager.MakePasskeyRequestOptionsAsync(model.User));

    [HttpPost(AuthenticationEndpoint.PostAddOrUpdatePasskey)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostAddOrUpdatePasskeyAsync(AddOrUpdatePasskeyRequest model) => Ok(await userManager.AddOrUpdatePasskeyAsync(model.User, model.UserPasskeyInfo));

    [HttpPost(AuthenticationEndpoint.PostAddLogin)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostAddLoginAsync(AddLoginRequest model) => Ok(await userManager.AddLoginAsync(model.User, model.UserLoginInfo));

    [HttpPost(AuthenticationEndpoint.PostMakePasskeyCreationOptions)]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostMakePasskeyCreationOptionsAsync(PasskeyUserEntity model) => Ok(await signInManager.MakePasskeyCreationOptionsAsync(model));

    [HttpPost(AuthenticationEndpoint.PostCreate)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostCreateAsync(CreateRequest model)
    {
        if (string.IsNullOrWhiteSpace(model.Password))
        {
            return Ok(await userManager.CreateAsync(model.User));
        }

        return Ok(await userManager.CreateAsync(model.User, model.Password));
    }

    [HttpPost(AuthenticationEndpoint.PostPerformPasskeyAttestation)]
    [ProducesResponseType<PasskeyAttestationResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostPerformPasskeyAttestationAsync(PerformPasskeyAttestationRequest model) => Ok(await signInManager.PerformPasskeyAttestationAsync(model.CredentialJson));

    [HttpPost(AuthenticationEndpoint.PostSetPhoneNumber)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostSetPhoneNumberAsync(SetPhoneNumberRequest model)
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(await userManager.SetPhoneNumberAsync(user, model.PhoneNumber));
    }

    [HttpPost(AuthenticationEndpoint.PostPasswordSignIn)]
    [ProducesResponseType<Microsoft.AspNetCore.Identity.SignInResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostPasswordSignInAsync(PasswordSignInRequest model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        return Ok(await signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, model.LockoutOnFailure));
    }

    [HttpPost(AuthenticationEndpoint.PostTwoFactorAuthenticatorSignIn)]
    [ProducesResponseType<Microsoft.AspNetCore.Identity.SignInResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostTwoFactorAuthenticatorSignInAsync(TwoFactorAuthenticatorSignInRequest model) => Ok(await signInManager.TwoFactorAuthenticatorSignInAsync(model.Code, model.IsPersistent, model.RememberClient));

    [HttpPost(AuthenticationEndpoint.PostFindUserId)]
    [ProducesResponseType<Guid>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostFindUserIdAsync(FindUserIdRequest model) => Ok(new Guid(await userManager.GetUserIdAsync(model.User)));

    [HttpGet(AuthenticationEndpoint.GetUserId)]
    [ProducesResponseType<Guid>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetUserIdAsync()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(user.Id);
    }

    [HttpPost(AuthenticationEndpoint.PostConfigureExternalAuthenticationProperties)]
    [ProducesResponseType<AuthenticationProperties>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public Task<IActionResult> PostConfigureExternalAuthenticationPropertiesAsync(ConfigureExternalAuthenticationPropertiesRequest model) => Task.FromResult<IActionResult>(Ok(signInManager.ConfigureExternalAuthenticationProperties(model.Provider, model.RedirectUrl, model.UserId.ToString())));

    [HttpPost(AuthenticationEndpoint.PostPasskeySignIn)]
    [ProducesResponseType<Microsoft.AspNetCore.Identity.SignInResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostPasskeySignInAsync(PasskeySignInRequest model) => Ok(await signInManager.PasskeySignInAsync(model.CredentialJson));

    [HttpPost(AuthenticationEndpoint.PostAddPassword)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostAddPasswordAsync(AddPasswordRequest model) => Ok(await userManager.AddPasswordAsync(model.User, model.Password));

    [HttpGet(AuthenticationEndpoint.GetLogins)]
    [ProducesResponseType<IList<UserLoginInfo>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetLoginsAsync()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(await userManager.GetLoginsAsync(user));
    }

    [HttpPost(AuthenticationEndpoint.PostRemovePasskey)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostRemovePasskeyAsync(RemovePasskeyRequest model) => Ok(await userManager.RemovePasskeyAsync(model.User, model.CredentialId.ToArray()));

    [HttpPost(AuthenticationEndpoint.PostGetPasskey)]
    [ProducesResponseType<UserPasskeyInfo>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostGetPasskeyAsync(GetPasskeyRequest model) => Ok(await userManager.GetPasskeyAsync(model.User, model.CredentialId.ToArray()));

    [HttpGet(AuthenticationEndpoint.GetPasskeys)]
    [ProducesResponseType<IList<UserPasskeyInfo>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetPasskeysAsync()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(await userManager.GetPasskeysAsync(user));
    }

    [HttpPost(AuthenticationEndpoint.PostCheckPassword)]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostCheckPasswordAsync(CheckPasswordRequest model) => Ok(await userManager.CheckPasswordAsync(model.User, model.Password));

    [HttpGet(AuthenticationEndpoint.GetGenerateNewTwoFactorRecoveryCodes)]
    [ProducesResponseType<IEnumerable<string>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetGenerateNewTwoFactorRecoveryCodesAsync([FromQuery] int? number)
    {
        var user = await userManager.GetUserAsync(User);

        if (!number.HasValue)
        {
            return BadRequest();
        }

        return Ok(await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number.Value) ?? []);
    }

    [HttpGet(AuthenticationEndpoint.GetById)]
    [ProducesResponseType<ApplicationUser>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString()) ?? throw new NotFoundException();

        return Ok(user);
    }

    [HttpPost(AuthenticationEndpoint.PostSetConfirmEmail)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostSetConfirmEmailAsync(ConfirmEmailRequest model)
    {
        var user = await userManager.FindByIdAsync(model.UserId.ToString()) ?? throw new NotFoundException();

        return Ok(await userManager.ConfirmEmailAsync(user, model.Code));
    }


    [HttpPost(AuthenticationEndpoint.PostConfirmEmail)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
    public async Task<IActionResult> PostConfirmEmailAsync(ConfirmEmailRequest confirmEmailRequest)
    {
        ArgumentNullException.ThrowIfNull(confirmEmailRequest);

        var user = await userManager.FindByIdAsync(confirmEmailRequest.UserId.ToString()) ?? throw new NotFoundException();

        var code = await userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        if (string.IsNullOrWhiteSpace(code))
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(" Return {Return} ConfirmEmailRequest {@ConfirmEmailRequest}", nameof(HttpStatusCode.NotFound), confirmEmailRequest);
            }

            throw new NotFoundException();
        }

        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
        }

        return Ok(code);
    }

    [HttpGet(AuthenticationEndpoint.GetAuthenticatorKey)]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAuthenticatorKeyAsync()
    {
        var user = await userManager.GetUserAsync(User);

        return Ok(await userManager.GetAuthenticatorKeyAsync(user));
    }

    [HttpGet(AuthenticationEndpoint.GetTwoFactorEnabled)]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetTwoFactorEnabledAsync()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(await userManager.GetTwoFactorEnabledAsync(user));
    }

    [HttpGet(AuthenticationEndpoint.GetIsTwoFactorClientRemembered)]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetIsTwoFactorClientRememberedAsync()
    {
        var user = await userManager.GetUserAsync(User);

        return Ok(await signInManager.IsTwoFactorClientRememberedAsync(user));
    }

    [HttpGet(AuthenticationEndpoint.GetCountRecoveryCodes)]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetCountRecoveryCodesAsync()
    {
        var user = await userManager.GetUserAsync(User);

        return Ok(await userManager.CountRecoveryCodesAsync(user));
    }

    [HttpGet(AuthenticationEndpoint.GetForgetTwoFactorClient)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetForgetTwoFactorClientAsync()
    {
        await signInManager.ForgetTwoFactorClientAsync();

        return Ok();
    }

    [HttpPost(AuthenticationEndpoint.PostTwoFactorRecoveryCodeSignIn)]
    [ProducesResponseType<Microsoft.AspNetCore.Identity.SignInResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostTwoFactorRecoveryCodeSignInAsync(TwoFactorRecoveryCodeSignInRequest model) => Ok(await signInManager.TwoFactorRecoveryCodeSignInAsync(model.RecoveryCode));

    [HttpGet(AuthenticationEndpoint.GetSetTwoFactorEnabled)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetSetTwoFactorEnabledAsync([FromQuery] bool enabled)
    {
        var user = await userManager.GetUserAsync(User);

        return Ok(await userManager.SetTwoFactorEnabledAsync(user, enabled));
    }

    [HttpGet(AuthenticationEndpoint.GetResetAuthenticatorKey)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetResetAuthenticatorKeyAsync()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(await userManager.ResetAuthenticatorKeyAsync(user));
    }


    [HttpGet(AuthenticationEndpoint.GetExternalAuthenticationSchemes)]
    [ProducesResponseType<IEnumerable<Microsoft.AspNetCore.Authentication.AuthenticationScheme>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetExternalAuthenticationSchemesAsync() => Ok(await signInManager.GetExternalAuthenticationSchemesAsync());

    [HttpGet(AuthenticationEndpoint.GetByName)]
    [ProducesResponseType<ApplicationUser>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetByNameAsync([FromQuery] string name) => Ok(await userManager.FindByNameAsync(name));

    [HttpDelete(AuthenticationEndpoint.Delete)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteAsync()
    {
        var user = await userManager.GetUserAsync(User);

        var result = await userManager.DeleteAsync(user);

        return Ok(result);
    }

    [HttpGet(AuthenticationEndpoint.GetHasPassword)]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetHasPasswordAsync()
    {
        var user = await userManager.GetUserAsync(User);

        return Ok(await userManager.HasPasswordAsync(user));
    }

    [HttpGet(AuthenticationEndpoint.GetGenerateChangeEmailToken)]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetGenerateChangeEmailTokenAsync([FromQuery] string email)
    {
        var user = await userManager.GetUserAsync(User);
        var token = await userManager.GenerateChangeEmailTokenAsync(user, email);

        return Ok(token);
    }

    [HttpPost(AuthenticationEndpoint.PostSignIn)]
    [ProducesResponseType<IList<System.Security.Claims.Claim>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostSignInAsync(SignInRequest model)
    {
        if (model.AuthenticationProperties != null)
        {
            await signInManager.SignInAsync(model.User, model.AuthenticationProperties, model.AuthenticationMethod);
        }
        else
        {
            await signInManager.SignInAsync(model.User, model.IsPersistent, model.AuthenticationMethod);
        }

        return Ok(await userManager.GetClaimsAsync(model.User));
    }

    [HttpGet(AuthenticationEndpoint.PostSetUserName)]
    [ProducesResponseType<IEnumerable<IdentityError>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostSetUserNameAsync(SetUserNameRequest model)
    {
        var result = await userManager.SetUserNameAsync(model.User, model.UserName);

        return Ok(result.Errors);
    }

    [HttpGet(AuthenticationEndpoint.PostChangeEmail)]
    [ProducesResponseType<IEnumerable<IdentityError>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostChangeEmailAsync(ChangeEmailRequest model)
    {
        var result = await userManager.ChangeEmailAsync(model.User, model.Email, model.Code);

        return Ok(result.Errors);
    }

    [HttpGet(AuthenticationEndpoint.PostRefreshSignIn)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostRefreshSignInAsync(RefreshSignInRequest model)
    {
        await signInManager.RefreshSignInAsync(model.User);

        return Ok();
    }


    [HttpGet(AuthenticationEndpoint.GetSignOut)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetSignOutAsync()
    {
        await signInManager.SignOutAsync();

        return Ok();
    }

    [HttpGet(AuthenticationEndpoint.GetByEmail)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<ApplicationUser>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByEmailAsync([FromQuery] string email) => Ok(await userManager.FindByEmailAsync(email));

    [HttpPost(AuthenticationEndpoint.PostGenerateEmailConfirmationToken)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public async Task<IActionResult> PostGenerateEmailConfirmationTokenAsync(GenerateEmailConfirmationTokenRequest model) => Ok(userManager.GenerateEmailConfirmationTokenAsync(model.User));

    [HttpGet(AuthenticationEndpoint.GetSupportsUserSecurityStamp)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    public Task<IActionResult> GetSupportsUserSecurityStampAsync() => Task.FromResult<IActionResult>(Ok(userManager.SupportsUserSecurityStamp));

    [HttpGet(AuthenticationEndpoint.GetSecurityStamp)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSecurityStampAsync()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(await userManager.GetSecurityStampAsync(user));
    }



    [HttpGet(AuthenticationEndpoint.GetTwoFactorAuthenticationUser)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<ApplicationUser>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTwoFactorAuthenticationUserAsync() => Ok(await signInManager.GetTwoFactorAuthenticationUserAsync());

    [HttpGet(AuthenticationEndpoint.GetExternalLoginInfo)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<ExternalLoginInfo>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExternalLoginInfoAsync() => Ok(await signInManager.GetExternalLoginInfoAsync());

    //[HttpPost(AuthenticationEndpoint.PostLogAccess)]
    //[ProducesDefaultResponseType]
    //[ProducesResponseType<AccessLogModel>(StatusCodes.Status200OK)]
    //public async Task<IActionResult> PostLogAccessAsync(AccessLogModel log)
    //{
    //    ArgumentNullException.ThrowIfNull(log);

    //    if (logger.IsEnabled(LogLevel.Information))
    //    {
    //        logger.LogInformation("Start log access {Email}", log.Email);
    //    }

    //    var access = await accessLogCommandService.UpdateByModelAsync(log, Guid.Empty, Guid.Empty);

    //    if (logger.IsEnabled(LogLevel.Information))
    //    {
    //        logger.LogInformation("{Email} logged", access.Email);
    //    }

    //    return Ok(access);
    //}


    [HttpGet(AuthenticationEndpoint.GetClaims)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<IEnumerable<string>>(StatusCodes.Status200OK)]
    public Task<IActionResult> GetClaimsAsync()
    {
        var claims = (from claim in User?.Claims
                      select $"{claim.Type}: {claim.Value}").ToList();

        return Task.FromResult<IActionResult>(Ok(claims));
    }

    [ProducesDefaultResponseType]
    [HttpGet(AuthenticationEndpoint.GetUser)]
    [ProducesResponseType<ApplicationUser>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserAsync()
    {
        var user = await userManager.GetUserAsync(User);

        return Ok(user);
    }


    [HttpPost(AuthenticationEndpoint.PostIsEmailPresent)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> PostIsEmailPresentAsync(ForgotPasswordRequest val)
    {
        ArgumentNullException.ThrowIfNull(val);
        var user = await userManager.FindByEmailAsync(val.Email);

        if (user is not null)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
            }

            return Ok();
        }

        throw new NotFoundException();
    }


    [HttpGet(AuthenticationEndpoint.GetGeneratePasswordResetToken)]
    [ProducesDefaultResponseType]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetGeneratePasswordResetTokenAsync([FromQuery] string email)
    {
        string code;
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        var user = await userManager.FindByEmailAsync(email) ?? throw new NotFoundException();

        code = await userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
        }

        return Ok(code);
    }


    [ProducesDefaultResponseType]
    [HttpPost(AuthenticationEndpoint.PostChangePassword)]
    [ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]

    public async Task<IActionResult> PostResetPasswordAsync(ResetPasswordRequest model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var userId = await userManager.GetUserIdAsync(model.User);

        var user = await userManager.FindByIdAsync(userId);

        if (user is null)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(" Return {Return} ResetPasswordRequest {@ResetPasswordRequest}", nameof(HttpStatusCode.NotFound), model);
            }

            throw new NotFoundException();
        }

        var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);

        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
        }

        return Ok(result);
    }

    //[ProducesDefaultResponseType]
    //[AllowAnonymous]
    //[HttpPost(AuthenticationEndpoint.PostResetPassword)]
    //[ProducesResponseType<IdentityResult>(StatusCodes.Status200OK)]
    //public async Task<IActionResult> PostResetPasswordAsync(ResetPasswordRequest model)
    //{
    //    ArgumentNullException.ThrowIfNull(model);

    //    var user = await userManager.FindByEmailAsync(model.Email);

    //    if (user is null)
    //    {
    //        if (logger.IsEnabled(LogLevel.Information))
    //        {
    //            logger.LogInformation("Return {Return} ResetPasswordRequest {@ResetPasswordRequest}", nameof(HttpStatusCode.NotFound), model);
    //        }

    //        throw new NotFoundException();
    //    }

    //    var data = WebEncoders.Base64UrlDecode(model.Code);
    //    model.Code = Encoding.UTF8.GetString(data);
    //    var userResult = await userManager.ResetPasswordAsync(user, model.Code, model.Password);

    //    if (!userResult.Succeeded)
    //    {
    //        return BadRequest();
    //    }

    //    if (logger.IsEnabled(LogLevel.Information))
    //    {
    //        logger.LogInformation(" Return {Return} ", nameof(HttpStatusCode.OK));
    //    }

    //    return Ok(userResult);
    //}
}
