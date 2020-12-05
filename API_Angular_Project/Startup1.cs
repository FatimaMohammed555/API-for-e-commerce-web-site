using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using API_Angular_Project.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(API_Angular_Project.Startup1))]

namespace API_Angular_Project
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new OAuthTokenCreate()
            });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //to handle the route {URL}
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute("Default", "api/{controller}/{id}",
            config.Routes.MapHttpRoute("Default", "{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });
            app.UseWebApi(config);

        }
    }

    internal class OAuthTokenCreate : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials
                   (OAuthGrantResourceOwnerCredentialsContext context)
        {
            //OWin Cors
            context.OwinContext.Response.Headers.Add("Access - Control - Allow - Origin", new[] { "*" });

            //Check USing IDentity username&password right
            ApplicationDbContext dbcontext = new ApplicationDbContext();
            UserStore<IdentityUser> userstore = new UserStore<IdentityUser>(dbcontext);
            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userstore);
            //UserManager()
            IdentityUser user = manager.Find(context.UserName, context.Password);
            //IdentityUser usertwo = await manager.FindAsync(context.UserName, context.Password);

            //var user = await UserManager.FindAsync(username, password);

            //IdentityUser identityUser = manager.FindAsync(string UserName ,);

            if (user == null)
            {
                context.SetError("grant_error", "Username & PAssword Not Found");
                return;
            }

            ClaimsIdentity Identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //information user ==>token "Name,Role ,email..."
            Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,user.Id));
            Identity.AddClaim(new Claim(ClaimTypes.Name,user.UserName));

            Identity.AddClaim(new Claim("age", "12"));
            Identity.GetUserId();
            //Identity.AddClaim(new Claim(ClaimTypes.Role,"admin,Student"));

            context.Validated(Identity);
        }

    }
}
