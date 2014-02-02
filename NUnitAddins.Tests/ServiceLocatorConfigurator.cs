using System;
using System.IO;
using System.Linq;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

using Microsoft.Practices.ServiceLocation;

using NUnit.Core;
using NUnit.Core.Extensibility;
using NUnit.Framework;

using NUnitAddin.Tests.tt;

using NUnitAddins;

namespace NUnitAddin.Tests {
	public class ServiceLocatorConfigurator {
		static ServiceLocatorConfigurator() {
			ServiceLocator.SetLocatorProvider(() => new NullLocator());

			var container = new WindsorContainer();

			container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));

			container.Register(
				Component.For<IWindsorContainer>()
					.Instance(container),

				Classes.FromThisAssembly()
					.Where(t => t.GetCustomAttributes(typeof(TestFixtureAttribute), true).Any())
					.WithServiceSelf(),

				Component.For<EventListener, CompositeEventListener>(),
				Component.For<EventListener, TestEventListener>(),

				Component.For<ITestDecorator, AddListenerDecorator>()
			);

			var serviceLocator = new WindsorServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => serviceLocator);
		}
	}
}