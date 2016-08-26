using System;
using BoDi;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowTests.SpecFlowExtensions
{
    public class UnityBindingInstanceResolver: IBindingInstanceResolver
    {
        #region Implementation of IBindingInstanceResolver

        public object ResolveBindingInstance(Type bindingType, IObjectContainer scenarioContainer)
        {
            var componentContext = scenarioContainer.Resolve<IUnityContainer>();
            return componentContext.Resolve(bindingType);
        }

        #endregion
    }
}
