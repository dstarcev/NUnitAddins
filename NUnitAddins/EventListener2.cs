using NUnit.Core;
using NUnit.Framework;

namespace NUnitAddins {
	public interface EventListener2 {
		void BeforeTest(TestResult result, TestDetails details);

		void AfterTest(TestResult result, TestDetails details);
	}
}