using System.Diagnostics.Contracts;

using NUnit.Core;
using NUnit.Framework;

namespace NUnitAddins {
	internal class EventListener2Action : ITestAction {
		private readonly EventListener2 _listener;

		public EventListener2Action(EventListener2 listener) {
			Contract.Requires(listener != null);

			_listener = listener;
		}

		public void BeforeTest(TestDetails testDetails) {
			var result = TestExecutionContext.CurrentContext.CurrentResult;
			if (result.Test.Properties["BeforeTest"] is bool) {
				return;
			}

			result.Test.Properties["BeforeTest"] = true;
			_listener.BeforeTest(result, testDetails);
		}

		public void AfterTest(TestDetails testDetails) {
			var result = TestExecutionContext.CurrentContext.CurrentResult;
			if (result.Test.Properties["AfterTest"] is bool) {
				return;
			}

			result.Test.Properties["AfterTest"] = true;
			_listener.AfterTest(result, testDetails);
		}

		public ActionTargets Targets {
			get {
				return ActionTargets.Test;
			}
		}
	}
}