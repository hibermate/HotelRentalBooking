using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelRentalBookingClient.Startup))]
namespace HotelRentalBookingClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
