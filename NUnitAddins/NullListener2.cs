using NUnit.Core;
using NUnit.Framework;

namespace NUnitAddins {
	public class NullListener2 : EventListener2 {
		public void BeforeTest(TestResult result, TestDetails details) {
		}

		public void AfterTest(TestResult result, TestDetails details) {
		}
	}
}