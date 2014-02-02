using System.Collections;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class LocatedTestCaseProvider2 : Located<ITestCaseProvider2>, ITestCaseProvider2 {
		public LocatedTestCaseProvider2(ITestCaseProvider2 defaultService)
			: base(defaultService) {
		}

		public bool HasTestCasesFor(MethodInfo method) {
			return Service.HasTestCasesFor(method);
		}

		public IEnumerable GetTestCasesFor(MethodInfo method) {
			return Service.GetTestCasesFor(method);
		}

		public bool HasTestCasesFor(MethodInfo method, Test suite) {
			return Service.HasTestCasesFor(method, suite);
		}

		public IEnumerable GetTestCasesFor(MethodInfo method, Test suite) {
			return Service.GetTestCasesFor(method, suite);
		}
	}
}