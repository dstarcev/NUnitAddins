using System;

using NUnit.Core;

namespace NUnitAddins {
	internal class LocatedEventListener : Located<EventListener>, EventListener {
		public LocatedEventListener(EventListener defaultService)
			: base(defaultService) {
		}

		public void RunStarted(string name, int testCount) {
			Service.RunStarted(name, testCount);
		}

		public void RunFinished(TestResult result) {
			Service.RunFinished(result);
		}

		public void RunFinished(Exception exception) {
			Service.RunFinished(exception);
		}

		public void TestStarted(TestName testName) {
			Service.TestStarted(testName);
		}

		public void TestFinished(TestResult result) {
			Service.TestFinished(result);
		}

		public void SuiteStarted(TestName testName) {
			Service.SuiteStarted(testName);
		}

		public void SuiteFinished(TestResult result) {
			Service.SuiteFinished(result);
		}

		public void UnhandledException(Exception exception) {
			Service.UnhandledException(exception);
		}

		public void TestOutput(TestOutput testOutput) {
			Service.TestOutput(testOutput);
		}
	}
}