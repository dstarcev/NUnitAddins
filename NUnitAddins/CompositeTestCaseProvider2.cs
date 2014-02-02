using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class CompositeTestCaseProvider2 : ITestCaseProvider2 {
		private readonly IEnumerable<ITestCaseProvider2> _collection;

		public CompositeTestCaseProvider2(IEnumerable<ITestCaseProvider2> collection) {
			Contract.Requires(collection != null);

			_collection = collection;
		}

		public bool HasTestCasesFor(MethodInfo method) {
			return _collection.Any(i => i.HasTestCasesFor(method));
		}

		public IEnumerable GetTestCasesFor(MethodInfo method) {
			return _collection
				.Where(i => i.HasTestCasesFor(method))
				.SelectMany(i => i.GetTestCasesFor(method).Cast<object>());
		}

		public bool HasTestCasesFor(MethodInfo method, Test suite) {
			return _collection.Any(i => i.HasTestCasesFor(method, suite));
		}

		public IEnumerable GetTestCasesFor(MethodInfo method, Test suite) {
			return _collection
				.Where(i => i.HasTestCasesFor(method, suite))
				.SelectMany(i => i.GetTestCasesFor(method, suite).Cast<object>());
		}
	}
}