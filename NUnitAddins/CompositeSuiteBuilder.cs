using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class CompositeSuiteBuilder : ISuiteBuilder {
		private readonly IEnumerable<ISuiteBuilder> _collection;

		public CompositeSuiteBuilder(IEnumerable<ISuiteBuilder> collection) {
			Contract.Requires(collection != null);

			_collection = collection;
		}

		public bool CanBuildFrom(Type type) {
			return _collection.Any(i => i.CanBuildFrom(type));
		}

		public Test BuildFrom(Type type) {
			var builder = _collection
				.First(i => i.CanBuildFrom(type));
		
			return builder.BuildFrom(type);
		}
	}
}