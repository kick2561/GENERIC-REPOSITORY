using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GenericRepository.Installers
{
    using GenericRepository.Generic_Repository;
    using GenericRepository.Models;
    using Plumbing;

    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
                        container.Register(
                        Classes.FromThisAssembly()
                        .BasedOn(typeof(IRepository< >))
                        .WithService.AllInterfaces()
                        .LifestylePerWebRequest());
            // container.Register(Component.For(typeof(IRepository<>)().ImplementedBy(typeof(Repository<>)())));
        }
	}
    public class EmployeeInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
                Component
                    .For<EmployeeEntity>()
                    .ImplementedBy<EmployeeEntity>()
                    .LifestyleTransient());
        }
    }
}

       