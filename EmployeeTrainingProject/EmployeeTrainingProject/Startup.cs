using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeTrainingProject.Startup))]
namespace EmployeeTrainingProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
