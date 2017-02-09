using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SPADemo.Notification.Installers;
using System.Web.Http.Controllers;

namespace SPADemo.NotificationService.Installer
{

    public class NotificationServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Types.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient());

            container.Install(FromAssembly.Containing(typeof(NotificationInstaller)));
        }
    }
}