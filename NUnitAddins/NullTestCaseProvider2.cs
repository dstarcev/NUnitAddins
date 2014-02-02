using System.Collections;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class NullTestCaseProvider2 : ITestCaseProvider2 {
		public bool HasTestCasesFor(MethodInfo method) {
			return false;
		}

		public IEnumerable GetTestCasesFor(MethodInfo method) {
			yield break;
		}

		public bool HasTestCasesFor(MethodInfo method, Test suite) {
			return false;
		}

		public IEnumerable GetTestCasesFor(MethodInfo method, Test suite) {
			yield break;
		}
	}
}