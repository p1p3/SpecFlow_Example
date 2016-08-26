using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using SpecFlowTests.SpecFlowExtensions;
using SpecFlowTests.Utils;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;

[assembly: RuntimePlugin(typeof(UnityPlugin))]
namespace SpecFlowTests.SpecFlowExtensions
{
    public class UnityPlugin:IRuntimePlugin
    {
        #region Implementation of IRuntimePlugin

        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            runtimePluginEvents.CustomizeGlobalDependencies += (sender, args) =>
            {
                args.ObjectContainer.RegisterTypeAs<UnityBindingInstanceResolver, IBindingInstanceResolver>();
            };

            runtimePluginEvents.CustomizeScenarioDependencies += (sender, args) =>
            {
                args.ObjectContainer.RegisterFactoryAs<IUnityContainer>(() =>
                {
                    return DependenciesTest.GetTestContainer();
                });
            };
        }

        #endregion
    }
}
