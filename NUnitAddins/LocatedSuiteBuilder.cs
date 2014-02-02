using System;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class LocatedSuiteBuilder : Located<ISuiteBuilder>, ISuiteBuilder {
		public LocatedSuiteBuilder(ISuiteBuilder defaultService)
			: base(defaultService) {
		}

		public bool CanBuildFrom(Type type) {
			return Service.CanBuildFrom(type);
		}

		public Test BuildFrom(Type type) {
			return Service.BuildFrom(type);
		}
	}
}