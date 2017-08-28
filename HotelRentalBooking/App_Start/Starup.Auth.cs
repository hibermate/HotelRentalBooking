using System;
using System.Configuration;

using Microsoft.Owin;
using Microsoft.Owin.Security;

using Owin;
using System.Web.Configuration;
using Microsoft.Owin.Security.Cookies;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using HotelRentalBooking.Credential;

namespace HotelRentalBooking.App_Start
{
    public class Starup
    {
        public void Configure(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(2),
                Provider = new SimpleAuthorizationServerProvider()

            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}