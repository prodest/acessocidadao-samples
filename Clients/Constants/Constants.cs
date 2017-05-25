using System;

namespace Constants
{
    public static class Constants
    {
        public const string BaseAddress = "https://developers.es.gov.br/acessocidadao/is";

        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";

        public const string ClientId = "";
        public const string ClientSecret = "";
    }
}