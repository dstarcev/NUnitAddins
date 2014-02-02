using System;
using System.Diagnostics.Contracts;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class AddListenerDecorator : ITestDecorator {
		private readonly EventListener _listener;

		public AddListenerDecorator(EventListener listener) {
			Contract.Requires(listener != null);

			_listener = listener;
		}

		public Test Decorate(Test test, MemberInfo member) {
			var nUnitTestMethod = test as NUnitTestMethod;
			if (nUnitTestMethod != null) {
				return new AddListenerWrapper(nUnitTestMethod, _listener);
			}

			return test;
		}
	}
}