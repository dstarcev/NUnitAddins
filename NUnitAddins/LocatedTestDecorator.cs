using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class LocatedTestDecorator : Located<ITestDecorator>, ITestDecorator {
		public LocatedTestDecorator(ITestDecorator defaultService)
			: base(defaultService) {
		}

		public Test Decorate(Test test, MemberInfo member) {
			return Service.Decorate(test, member);
		}
	}
}