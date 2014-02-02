using Castle.Windsor;
using Castle.Windsor.Installer;

using Microsoft.Practices.ServiceLocation;

using NUnitAddins;
using NUnitAddins.Tests.Configuration;

[assembly: InitializeOnLoad(typeof(ServiceLocatorConfigurator))]

namespace NUnitAddins.Tests.Configuration {
	public static class ServiceLocatorConfigurator {
		static ServiceLocatorConfigurator() {
			var container = new WindsorContainer();
			container.Install(FromAssembly.This());
			var locator = new WindsorServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => locator);
		}
	}
}