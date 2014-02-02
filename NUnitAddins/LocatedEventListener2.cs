using NUnit.Core;
using NUnit.Framework;

namespace NUnitAddins {
	internal class LocatedEventListener2 : Located<EventListener2>, EventListener2 {
		public LocatedEventListener2(EventListener2 defaultService)
			: base(defaultService) {
		}

		public void BeforeTest(TestResult result, TestDetails details) {
			Service.BeforeTest(result, details);
		}

		public void AfterTest(TestResult result, TestDetails details) {
			Service.AfterTest(result, details);
		}
	}
}