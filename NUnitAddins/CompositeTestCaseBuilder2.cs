using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class CompositeTestCaseBuilder2 : ITestCaseBuilder2 {
		private readonly IEnumerable<ITestCaseBuilder2> _collection;

		public CompositeTestCaseBuilder2(IEnumerable<ITestCaseBuilder2> collection) {
			Contract.Requires(collection != null);

			_collection = collection;
		}

		public bool CanBuildFrom(MethodInfo method) {
			return _collection.Any(i => i.CanBuildFrom(method));
		}

		public Test BuildFrom(MethodInfo method) {
			var builder = _collection
				.First(i => i.CanBuildFrom(method));

			return builder.BuildFrom(method);
		}

		public bool CanBuildFrom(MethodInfo method, Test suite) {
			return _collection.Any(i => i.CanBuildFrom(method, suite));
		}

		public Test BuildFrom(MethodInfo method, Test suite) {
			var builder = _collection
				.First(i => i.CanBuildFrom(method, suite));

			return builder.BuildFrom(method, suite);
		}
	}
}