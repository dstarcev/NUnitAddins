using System.Collections;
using System.Reflection;

using NUnit.Core.Extensibility;

namespace NUnitAddins {
	public class NullDataPointProvider : IDataPointProvider {
		public bool HasDataFor(ParameterInfo parameter) {
			return false;
		}

		public IEnumerable GetDataFor(ParameterInfo parameter) {
			yield break;
		}
	}
}