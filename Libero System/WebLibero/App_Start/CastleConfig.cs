using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Libero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Libero.Interfaces;
using Libero.Repositorios;

namespace WebLibero.App_Start
{
    public class CastleConfig
    {
        private static IWindsorContainer container = new WindsorContainer();
        public static IWindsorContainer Container
        {
            get { return container; }
        }
        public static void Configure()
        {
            container.Install(FromAssembly.This());
        }
        public static void Unload()
        {
            container.Dispose();
        }
    }

    public class AppWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Cliente>());
            container.Register(Component.For<IRepoCliente>().ImplementedBy<RepoCliente>());
            container.Register(Component.For<IRepoFabricante>().ImplementedBy<RepoFabricante>());
            container.Register(Component.For<IRepoModelo>().ImplementedBy<RepoModelo>());
            container.Register(Component.For<IRepoLocacao>().ImplementedBy<RepoLocacao>());
            
        }
    }
}