using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using NUnit.Core;

namespace NUnitAddins {
	public class CompositeEventListener : EventListener {
		private readonly IEnumerable<EventListener> _collection;

		public CompositeEventListener(params EventListener[] collection)
			: this((IEnumerable<EventListener>)collection) {
		}

		public CompositeEventListener(IEnumerable<EventListener> collection) {
			Contract.Requires(collection != null);

			_collection = collection;
		}

		public void RunStarted(string name, int testCount) {
			foreach (var listener in _collection) {
				listener.RunStarted(name, testCount);
			}
		}

		public void RunFinished(TestResult result) {
			foreach (var listener in _collection) {
				listener.RunFinished(result);
			}
		}

		public void RunFinished(Exception exception) {
			foreach (var listener in _collection) {
				listener.RunFinished(exception);
			}
		}

		public void TestStarted(TestName testName) {
			foreach (var listener in _collection) {
				listener.TestStarted(testName);
			}
		}

		public void TestFinished(TestResult result) {
			foreach (var listener in _collection) {
				listener.TestFinished(result);
			}
		}

		public void SuiteStarted(TestName testName) {
			foreach (var listener in _collection) {
				listener.SuiteStarted(testName);
			}
		}

		public void SuiteFinished(TestResult result) {
			foreach (var listener in _collection) {
				listener.SuiteFinished(result);
			}
		}

		public void UnhandledException(Exception exception) {
			foreach (var listener in _collection) {
				listener.UnhandledException(exception);
			}
		}

		public void TestOutput(TestOutput testOutput) {
			foreach (var listener in _collection) {
				listener.TestOutput(testOutput);
			}
		}
	}
}