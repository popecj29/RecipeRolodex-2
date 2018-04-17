using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeRolodex.Startup))]
namespace RecipeRolodex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
