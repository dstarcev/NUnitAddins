using System.Collections.Generic;
using System.Diagnostics.Contracts;

using NUnit.Core;
using NUnit.Framework;

namespace NUnitAddins {
	public class CompositeEventListener2 : EventListener2 {
		private readonly IEnumerable<EventListener2> _listeners;

		public CompositeEventListener2(IEnumerable<EventListener2> listeners) {
			Contract.Requires(listeners != null);

			_listeners = listeners;
		}

		public void BeforeTest(TestResult result, TestDetails details) {
			foreach (var listener in _listeners) {
				listener.BeforeTest(result, details);
			}
		}

		public void AfterTest(TestResult result, TestDetails details) {
			foreach (var listener in _listeners) {
				listener.AfterTest(result, details);
			}
		}
	}
}