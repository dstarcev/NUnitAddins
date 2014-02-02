using System;

using NUnit.Core;
using NUnit.Framework;

namespace NUnitAddins.Tests.Configuration {
	public class TestEventListener : EventListener, EventListener2 {
		public void RunStarted(string name, int testCount) {
			Console.WriteLine("RunStarted");
		}

		public void RunFinished(TestResult result) {
			Console.WriteLine("RunFinished");
		}

		public void RunFinished(Exception exception) {
			Console.WriteLine("RunFinished");
		}

		public void TestStarted(TestName testName) {
			Console.WriteLine("TestStarted");
		}

		public void TestFinished(TestResult result) {
			Console.WriteLine("TestFinished " + result.Name);
		}

		public void SuiteStarted(TestName testName) {
			Console.WriteLine("SuiteStarted");
		}

		public void SuiteFinished(TestResult result) {
			Console.WriteLine("SuiteFinishef");
		}

		public void UnhandledException(Exception exception) {
			Console.WriteLine("UnhandledException");
		}

		public void TestOutput(TestOutput testOutput) {
		}

		public void BeforeTest(TestResult result, TestDetails details) {
			Console.WriteLine("BeforeTest");
		}

		public void AfterTest(TestResult result, TestDetails details) {
			Console.WriteLine("AfterTest");
		}
	}
}