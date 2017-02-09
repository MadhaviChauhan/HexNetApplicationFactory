using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SPADemo.Common.Interceptor;
using SPADemo.DataAccess.Installers;
using ServicesGateway.Installers;

namespace SPADemo.BusinessServices.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
                Classes.FromThisAssembly()
                    .IncludeNonPublicTypes()
                    .Pick()
                    .WithServiceBase().WithServiceAllInterfaces()
                    .LifestyleTransient()
                    .Configure(component => component.Interceptors<LoggingInterceptorCastle>()
                    )
                );


            container.Install(FromAssembly.Containing(typeof(DataInstaller)));
            container.Install(FromAssembly.Containing(typeof(ServiceGatewayInstaller)));

        }
    }
}