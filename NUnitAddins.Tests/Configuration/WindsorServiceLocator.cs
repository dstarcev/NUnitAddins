using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Castle.Windsor;

using Microsoft.Practices.ServiceLocation;

namespace NUnitAddins.Tests.Configuration {
	public class WindsorServiceLocator : ServiceLocatorImplBase {
		private readonly IWindsorContainer _container;

		public WindsorServiceLocator(IWindsorContainer container) {
			Contract.Requires(container != null);
			_container = container;
		}

		protected override object DoGetInstance(Type serviceType, string key) {
			if (key != null) {
				return _container.Resolve(key, serviceType);
			}

			return _container.Resolve(serviceType);
		}

		protected override IEnumerable<object> DoGetAllInstances(Type serviceType) {
			return (object[])_container.ResolveAll(serviceType);
		}
	}
}