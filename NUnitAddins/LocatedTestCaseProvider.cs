using System.Collections;
using System.Reflection;

using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class LocatedTestCaseProvider : Located<ITestCaseProvider>, ITestCaseProvider {
		public LocatedTestCaseProvider(ITestCaseProvider defaultService)
			: base(defaultService) {
		}

		public bool HasTestCasesFor(MethodInfo method) {
			return Service.HasTestCasesFor(method);
		}

		public IEnumerable GetTestCasesFor(MethodInfo method) {
			return Service.GetTestCasesFor(method);
		}
	}
}