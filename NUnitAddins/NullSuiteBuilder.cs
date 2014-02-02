using System;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class NullSuiteBuilder : ISuiteBuilder {
		public bool CanBuildFrom(Type type) {
			return false;
		}

		public Test BuildFrom(Type type) {
			throw new NotSupportedException();
		}
	}
}