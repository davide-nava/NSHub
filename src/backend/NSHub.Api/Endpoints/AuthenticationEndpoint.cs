// <copyright file="AuthenticationEndpoint.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

namespace NSHub.Endpoints.Api;

public class AuthenticationEndpoint
{
    public const string ConfigurationBase = "/api/authentication";

    public const string GetLogout = ConfigurationBase + "/logout";

    public const string GetClaims = ConfigurationBase + "/claims";

    public const string PostLogin = ConfigurationBase + "/login";

    public const string PostLoginUseCookies = ConfigurationBase + "/login";

    public const string PostLogAccess = ConfigurationBase + "/logaccess";

    public const string PostRegister = ConfigurationBase + "/register";

    public const string PostRefresh = ConfigurationBase + "/refresh";

    public const string GetConfirmEmail = ConfigurationBase + "/confirmemail";

    public const string PostResendConfirmationEmail = ConfigurationBase + "/resendconfirmationemail";

    public const string PostForgotPassword = ConfigurationBase + "/forgotpassword";

    public const string PostResetPassword = ConfigurationBase + "/reset-password";

    public const string PostManage2Fa = ConfigurationBase + "/manage/2fa";

    public const string GetManageInfo = ConfigurationBase + "/manage/info";

    public const string PostManageInfo = ConfigurationBase + "/manage/info";

    public const string PostIsEmailPresent = ConfigurationBase + "/isemailpresent";

    public const string GetGeneratePasswordResetToken = ConfigurationBase + "/generatepasswordresettoken";

    public const string PostConfirmEmail = ConfigurationBase + "/confirmemail";
    public const string PostSetConfirmEmail = ConfigurationBase + "/setconfirmemail";

    public const string PostChangePassword = ConfigurationBase + "/changepassword";

    public const string GetUserByClaimsPrincipal = ConfigurationBase + "/getuserbyclaimsprincipal";

    public const string GetExternalLoginInfo = ConfigurationBase + "/getexternallogininfo";

    public const string GetTwoFactorAuthenticationUser = ConfigurationBase + "/gettwofactorauthenticationuser";

    public const string GetSecurityStamp = ConfigurationBase + "/getsecuritystamp";

    public const string GetSupportsUserSecurityStamp = ConfigurationBase + "/supportsusersecuritystamp";
    public const string PostGenerateEmailConfirmationToken = ConfigurationBase + "/generateemailconfirmationtoken";
    public const string GetByEmail = ConfigurationBase + "/getbyemail";
    public const string GetUser = ConfigurationBase + "/getuser";
    public const string GetSignOut = ConfigurationBase + "/signout";
    public const string GetUserId = ConfigurationBase + "/getuserid";

    public const string PostSetUserName = ConfigurationBase + "/setusername";
    public const string PostChangeEmail = ConfigurationBase + "/changeemail";
    public const string PostRefreshSignIn = ConfigurationBase + "/refreshsignin";
    public const string PostSignIn = ConfigurationBase + "/signin";
    public const string GetGenerateChangeEmailToken = ConfigurationBase + "/generatechangeemailtoken";
    public const string GetHasPassword = ConfigurationBase + "/haspassword";
    public const string Delete = ConfigurationBase + "/delete";
    public const string GetByName = ConfigurationBase + "/getbyname";
    public const string GetExternalAuthenticationSchemes = ConfigurationBase + "/getexternalauthenticationschemes";
    public const string GetSetTwoFactorEnabled = ConfigurationBase + "/getsettwofactorenabled";
    public const string GetResetAuthenticatorKey = ConfigurationBase + "/getresetauthenticatorkey";
    public const string PostTwoFactorRecoveryCodeSignIn = ConfigurationBase + "/twofactorrecoverycodesignin";
    public const string GetAuthenticatorKey = ConfigurationBase + "/authenticatorkey";
    public const string GetTwoFactorEnabled = ConfigurationBase + "/twofactorenabled";
    public const string GetIsTwoFactorClientRemembered = ConfigurationBase + "/istwofactorclientremembered";
    public const string GetCountRecoveryCodes = ConfigurationBase + "/countrecoverycodes";
    public const string GetForgetTwoFactorClient = ConfigurationBase + "/forgettwofactorclient";
    public const string GetById = ConfigurationBase + "/getbyid";
    public const string GetGenerateNewTwoFactorRecoveryCodes = ConfigurationBase + "/generatenewtwofactorrecoverycodes";
    public const string PostCheckPassword = ConfigurationBase + "/checkpassword";
    public const string GetPasskeys = ConfigurationBase + "/getpasskeys";
    public const string PostRemovePasskey = ConfigurationBase + "/removepasskey";
    public const string GetLogins = ConfigurationBase + "/getlogins";
    public const string PostGetPasskey = ConfigurationBase + "/getpasskey";
    public const string PostAddPassword = ConfigurationBase + "/addpassword";
    public const string PostPasskeySignIn = ConfigurationBase + "/passkeysignin";
    public const string PostConfigureExternalAuthenticationProperties = ConfigurationBase + "/configureexternalauthenticationproperties";
    public const string PostTwoFactorAuthenticatorSignIn = ConfigurationBase + "/twofactorauthenticatorsignin";
    public const string PostPasswordSignIn = ConfigurationBase + "/passwordsignin";
    public const string PostSetPhoneNumber = ConfigurationBase + "/setphonenumber";
    public const string PostPerformPasskeyAttestation = ConfigurationBase + "/performpasskeyattestation";
    public const string PostCreate = ConfigurationBase + "/create";
    public const string PostMakePasskeyCreationOptions = ConfigurationBase + "/makepasskeycreationoptions";
    public const string PostAddLogin = ConfigurationBase + "/addlogin";
    public const string PostAddOrUpdatePasskey = ConfigurationBase + "/addorupdatepasskey";
    public const string PostMakePasskeyRequestOptions = ConfigurationBase + "/makepasskeyrequestoptions";
    public const string PostExternalLoginSignIn = ConfigurationBase + "/externalloginsignin";
    public const string PostResetAuthenticatorKey = ConfigurationBase + "/resetauthenticatorkey";
    public const string PostRemoveLogin = ConfigurationBase + "/removelogin";
    public const string PostVerifyTwoFactorToken = ConfigurationBase + "/verifytwofactortoken";
    public const string GetAuthenticatorTokenProvider = ConfigurationBase + "/authenticatortokenprovider";
    public const string GetSupportsUserEmail = ConfigurationBase + "/supportsuseremail";
    public const string GetSetEmail = ConfigurationBase + "/setemail";
    public const string GetRequireConfirmedAccount = ConfigurationBase + "/requireconfirmedaccount";
    public const string GetEmailStore = ConfigurationBase + "/emailstore";
    public const string PostSetEmail = ConfigurationBase + "/setemail";
    public const string PostSetUserNameUserStore = ConfigurationBase + "/setusernameuserstore";
    public const string PostSetEmailUserStore = ConfigurationBase + "/setemailuserstore";
    public const string PostGetByClaimsPrincipal = ConfigurationBase + "/getbyclaimsprincipal";
    public const string GetUserPasswordStore = ConfigurationBase + "/userpasswordstore";
    public const string PostFindUserId = ConfigurationBase + "/finduserid";

    public string GetGeneratePasswordResetTokenUrl(string email)
    {
        return GetGeneratePasswordResetToken + "?email={email}";
    }

    public string GetByEmailUrl(string email)
    {
        return GetByEmail + "?email={email}";
    }

    public string GetGenerateChangeEmailTokenUrl(string email)
    {
        return GetGenerateChangeEmailToken + "?email={email}";
    }

    public string GetByNameUrl(string name)
    {
        return GetByName + "?name={name}";
    }

    public string GetSetTwoFactorEnabledUrl(bool enabled)
    {
        return GetSetTwoFactorEnabled + "?enabled={enabled}";
    }

    public string GetGenerateNewTwoFactorRecoveryCodesUrl(int number)
    {
        return GetGenerateNewTwoFactorRecoveryCodes + "?number={number}";
    }

    public string GetByIdUrl(Guid id)
    {
        return GetById + "?id={id}";
    }
}
