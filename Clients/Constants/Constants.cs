using System;

namespace Samples
{
    public static class Constants
    {
        public const string BaseAddress = "https://developers.es.gov.br/acessocidadao/is";

        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";

        public const string ClientIdImplicit = "f751504d-dd45-47ee-8551-7cf0e40c29eb";
        public const string ClientSecret = "";
    }
}