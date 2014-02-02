using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using NUnit.Core;

namespace NUnitAddins.Tests.Configuration {
	public class AddinInstaller : IWindsorInstaller {
		public void Install(IWindsorContainer container, IConfigurationStore store) {
			container.Register(
				Component.For<EventListener, EventListener2, TestEventListener>()
			);
		}
	}
}