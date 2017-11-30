using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(C43QLXeKhach.Startup))]
namespace C43QLXeKhach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
