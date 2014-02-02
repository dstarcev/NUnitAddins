using System.Diagnostics.Contracts;

using NUnit.Core;

namespace NUnitAddins {
	internal class AddListenerWrapper : NUnitTestMethod {
		private readonly EventListener _listener;

		public AddListenerWrapper(NUnitTestMethod testMethod, EventListener listener)
			: base(testMethod.Method) {
			Contract.Requires(testMethod != null);
			Contract.Requires(listener != null);

			_listener = listener;
		}

		public override TestResult Run(EventListener listener, ITestFilter filter) {
			var newListener = new CompositeEventListener(listener, _listener);

			return base.Run(newListener, filter);
		}
	}
}