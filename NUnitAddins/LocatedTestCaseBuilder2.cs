using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class LocatedTestCaseBuilder2 : Located<ITestCaseBuilder2>, ITestCaseBuilder2 {
		public LocatedTestCaseBuilder2(ITestCaseBuilder2 defaultService)
			: base(defaultService) {
		}

		public bool CanBuildFrom(MethodInfo method) {
			return Service.CanBuildFrom(method);
		}

		public Test BuildFrom(MethodInfo method) {
			return Service.BuildFrom(method);
		}

		public bool CanBuildFrom(MethodInfo method, Test suite) {
			return Service.CanBuildFrom(method, suite);
		}

		public Test BuildFrom(MethodInfo method, Test suite) {
			return Service.BuildFrom(method, suite);
		}
	}
}