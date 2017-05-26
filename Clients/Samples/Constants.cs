using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public static class Constants
    {
        public const string BaseAddress = "https://developers.es.gov.br/acessocidadao/is";
        public const string RedirectUriCorporativo = "https://localhost:44345/";
        public const string RedirectUriImplicit = "https://localhost:44358/";

        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";

        public const string ClientIdCorporativo = "e5bd55b7-d1e5-4f22-a1db-475965436c22";
        public const string ClientSecretCorporativo = "Ns70NyK3Q9L8&Jr9WyVnJb @wI0KCgoMW";
        public const string ClientIdImplicit = "f751504d-dd45-47ee-8551-7cf0e40c29eb";
    }
}