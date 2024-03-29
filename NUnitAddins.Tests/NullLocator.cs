﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.ServiceLocation;

using NUnit.Framework;

namespace NUnitAddin.Tests {
	public class NullLocator : IServiceLocator {
		public object GetService(Type serviceType) {
			throw new NotImplementedException();
		}

		public object GetInstance(Type serviceType) {
			throw new NotImplementedException();
		}

		public object GetInstance(Type serviceType, string key) {
			throw new NotImplementedException();
		}

		public IEnumerable<object> GetAllInstances(Type serviceType) {
			throw new NotImplementedException();
		}

		public TService GetInstance<TService>() {
			throw new NotImplementedException();
		}

		public TService GetInstance<TService>(string key) {
			throw new NotImplementedException();
		}

		public IEnumerable<TService> GetAllInstances<TService>() {
			throw new NotImplementedException();
		}
	}
}
