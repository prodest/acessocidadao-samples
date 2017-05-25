using Microsoft.Owin;
using Owin;
using System.Web.Helpers;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Samples;
using System.Security.Claims;
using IdentityModel.Client;
using System;
using System.Linq;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(MVC.Owin.Implicit.Startup))]

namespace MVC.Owin.Implicit
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Define que a chave do usuário vem da Claim "sub"
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "sub";
            // Desliga o mapeamento automático de Claims do asp.net, os nomes ficam como as
            // Claims do Acesso Cidadão..
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            // Configurar o OWIN para gerenciar autenticação usando Cookies
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            // Configurando para fazer autenticação usando OpenID Connect
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = Constants.BaseAddress,
                ClientId = Constants.ClientIdImplicit,
                RedirectUri = "https://localhost:44358/",
                ResponseType = "id_token",
                // Qualquer scope além desses apenas para sistemas corporativos do estado
                // e precisa de permissão explicita da área responsável. Fazer requisição devidamente
                // fundamentada de porque a informação é necessária
                Scope = "openid cpf nome email",
                //Essas permissões só podem ser usadas em sistemas corporativos
                //Scope = "openid cpf nome email dataNascimento permissoes roles",

                // Configura o middleware do openid connect para usar o middleware configurado acima
                // para controlar a autenticação usando cookies
                SignInAsAuthenticationType = "Cookies",

                // Essa parte é totalmente opcional
                // Nesse exemplo a gente vai usar ela para apagar algumas claims que vem do Acesso Cidadão
                // e não queremos guardar e para setar o nome da identity
                // Mas também pode ser usada para fazer qualquer tipo de mapeamento das claims que vem do Acesso Cidadão
                // Por exemplo: Trocar o nome, por primeiro nome e sobrenome, mapear as permissões para outra
                // representação e assim por diante
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        // Criando uma nova claims identity e falando que a Claim "nome" deve ser mapeada para o
                        // name do User e a claim "role" pode ser usada para controlar as roles do User
                        var nid = new ClaimsIdentity(
                            n.AuthenticationTicket.Identity.AuthenticationType,
                            "nome",
                            "role");

                        // Pegando as claims que o middleware já mapeou automático do retorno do Acesso Cidadão
                        // Nesse exemplo não existem roles, o grupo está vazio, mas se tivesse seria mapeado
                        // desse jeito
                        var userInfo = n.AuthenticationTicket.Identity;
                        var userInfoList = userInfo.Claims.ToList();

                        var sub = userInfo.FindFirst("sub");
                        var nome = userInfo.FindFirst("apelido") != null ? userInfo.FindFirst("apelido") : new Claim("apelido", userInfo.FindFirst("nome").Value);
                        var nomeCompleto = userInfo.FindFirst("nome");
                        var email = userInfo.FindFirst("email");
                        var cpf = userInfo.FindFirst("cpf");
                        var roles = userInfo.FindAll("role");
                        nid.AddClaim(sub);
                        nid.AddClaim(nome);
                        nid.AddClaim(nomeCompleto);
                        nid.AddClaim(email);
                        nid.AddClaim(cpf);
                        nid.AddClaims(roles);

                        nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

                        n.AuthenticationTicket = new AuthenticationTicket(
                            nid,
                            n.AuthenticationTicket.Properties);

                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}