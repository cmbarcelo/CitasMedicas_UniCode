using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CitasMedicas_UniCode.Startup))]
namespace CitasMedicas_UniCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
