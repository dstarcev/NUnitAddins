using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class LocatedTestCaseBuilder : Located<ITestCaseBuilder>, ITestCaseBuilder {
		public LocatedTestCaseBuilder(ITestCaseBuilder defaultService)
			: base(defaultService) {
		}

		public bool CanBuildFrom(MethodInfo method) {
			return Service.CanBuildFrom(method);
		}

		public Test BuildFrom(MethodInfo method) {
			return Service.BuildFrom(method);
		}
	}
}