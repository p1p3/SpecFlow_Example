using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using SeleniumWebDriver.Drivers;
using SpecFlow.Unity;
using SpecFlowHelpers.Configuration;
using SpecFlowHelpers.Database.Definitions;
using SpecFlowHelpers.Database.Definitions.Manager;
using SpecFlowHelpers.Database.Implementations;
using SpecFlowHelpers.Database.Implementations.Manager;
using SpecFlowHelpers.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Utils
{
    public static class DependenciesTest
    {
        [ScenarioDependencies]
        public static IUnityContainer GetTestContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IAppConfiguration, AppConfiguration>();
            container.RegisterType<IDriver, FirefoxWebDriver>();
            container.RegisterType<ITestDriver, FirefoxTestBase>();
            

            var appConfig = container.Resolve<IAppConfiguration>();
            //Base de datos de tepresta
            const string dependencyTePrestaName = "dbManagerTepresta";
            var dbTeprestaConnectionString =
                ConfigurationManager.ConnectionStrings["SucursalVirtualSqlServer"].ConnectionString;
            var injectionConstructorTePresta = new InjectionConstructor(dbTeprestaConnectionString, appConfig);
            container.RegisterType<IDatabaseManager, DatabaseManagerSqlServer>(injectionMembers: injectionConstructorTePresta, name: dependencyTePrestaName);

            //Base de datos de seguridad
            const string dependencySecurityName = "dbManagerSeguridad";
            var dbSeguridadConnectionString =
               ConfigurationManager.ConnectionStrings["SeguridadSucursalVirtualSqlServer"].ConnectionString;
            var injectionConstructorSeguridad = new InjectionConstructor(dbSeguridadConnectionString, appConfig);
            container.RegisterType<IDatabaseManager, DatabaseManagerSqlServer>(injectionMembers: injectionConstructorSeguridad, name: dependencySecurityName);


            //Funciones te presta
            var dbManagerTePresta = container.Resolve<IDatabaseManager>(dependencyTePrestaName);
            var dbManagerSeguridad = container.Resolve<IDatabaseManager>(dependencySecurityName);
            var injectionConstructorTeprestaFunctions = new InjectionConstructor(dbManagerTePresta, dbManagerSeguridad);
            container.RegisterType<ITeprestaFunctions, TeprestaFunctions>(injectionConstructorTeprestaFunctions);

            //Requerido por specflow
            container.RegisterTypes(typeof(DependenciesTest).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray(), getLifetimeManager: WithLifetime.ContainerControlled);
            return container;
        }


    }
}
