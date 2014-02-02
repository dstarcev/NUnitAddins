using System;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class NullTestCaseBuilder2 : ITestCaseBuilder2 {
		public bool CanBuildFrom(MethodInfo method) {
			return false;
		}

		public Test BuildFrom(MethodInfo method) {
			throw new NotSupportedException();
		}

		public bool CanBuildFrom(MethodInfo method, Test suite) {
			return false;
		}

		public Test BuildFrom(MethodInfo method, Test suite) {
			throw new NotSupportedException();
		}
	}
}