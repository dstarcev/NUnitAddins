using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class CompositeDataPointProvider : IDataPointProvider {
		private readonly IEnumerable<IDataPointProvider> _collection;

		public CompositeDataPointProvider(IEnumerable<IDataPointProvider> collection) {
			Contract.Requires(collection != null);

			_collection = collection;
		}

		public bool HasDataFor(ParameterInfo parameter) {
			return _collection.Any(i => i.HasDataFor(parameter));
		}

		public IEnumerable GetDataFor(ParameterInfo parameter) {
			return _collection
				.Where(i => i.HasDataFor(parameter))
				.SelectMany(i => i.GetDataFor(parameter).Cast<object>());
		}
	}
}