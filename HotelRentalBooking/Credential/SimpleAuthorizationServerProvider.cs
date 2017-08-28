using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
namespace HotelRentalBooking.Credential
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
        {
            context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
        }
      
    }
}