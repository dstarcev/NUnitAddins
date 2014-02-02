using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class NullTestDecorator : ITestDecorator {
		public Test Decorate(Test test, MemberInfo member) {
			return test;
		}
	}
}