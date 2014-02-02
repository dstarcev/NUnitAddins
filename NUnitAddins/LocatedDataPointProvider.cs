using System.Collections;
using System.Reflection;

using NUnit.Core.Extensibility;

namespace NUnitAddins {
	internal class LocatedDataPointProvider : Located<IDataPointProvider>, IDataPointProvider {
		public LocatedDataPointProvider(IDataPointProvider defaultService)
			: base(defaultService) {
		}

		public bool HasDataFor(ParameterInfo parameter) {
			return Service.HasDataFor(parameter);
		}

		public IEnumerable GetDataFor(ParameterInfo parameter) {
			return Service.GetDataFor(parameter);
		}
	}
}