using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SPADemo.Common.Interceptor;
using SPADemo.DataAccess.Context;
using SPADemo.DataAccessInterface.Repository;
namespace SPADemo.DataAccess.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
                Classes.FromAssembly(typeof(DataInstaller).Assembly)
                       .BasedOn(typeof(IRepository<>), typeof(IUnitOfWork), typeof(DapperContext))
                       .WithServiceBase()
                       .WithServiceAllInterfaces()
                       .LifestyleTransient().Configure(component => component.Interceptors<LoggingInterceptorCastle>())
                );
            //Register Logging Interceptor;
            container.Register(Component.For<IInterceptor>()
                     .ImplementedBy<LoggingInterceptorCastle>());
            //Register Container to inject into Unit of Work
            container.Register(Component.For<IWindsorContainer>().Instance(container));

        }
    }
}