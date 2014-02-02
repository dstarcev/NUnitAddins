using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class CompositeTestDecorator : ITestDecorator {
		private readonly IEnumerable<ITestDecorator> _collection;

		public CompositeTestDecorator(IEnumerable<ITestDecorator> collection) {
			Contract.Requires(collection != null);

			_collection = collection;
		}

		public Test Decorate(Test test, MemberInfo member) {
			var result = test;
			foreach (var decorator in _collection) {
				result = decorator.Decorate(result, member);
			}

			return result;
		}
	}
}