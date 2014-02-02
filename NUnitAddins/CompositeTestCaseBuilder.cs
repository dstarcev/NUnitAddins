using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class CompositeTestCaseBuilder : ITestCaseBuilder {
		private readonly IEnumerable<ITestCaseBuilder> _collection;

		public CompositeTestCaseBuilder(IEnumerable<ITestCaseBuilder> collection) {
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
	}
}