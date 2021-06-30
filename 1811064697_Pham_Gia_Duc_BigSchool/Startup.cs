using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1811064697_Pham_Gia_Duc_BigSchool.Startup))]
namespace _1811064697_Pham_Gia_Duc_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
