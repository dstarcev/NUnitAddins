using System;
using System.Diagnostics.Contracts;

using Microsoft.Practices.ServiceLocation;

namespace NUnitAddins {
	internal abstract class Located<T> {
		private readonly T _defaultService;

		protected Located(T defaultService) {
			Contract.Requires(defaultService != null);

			_defaultService = defaultService;
		}

		protected T Service {
			get {
				try {
					return ServiceLocator.Current.GetInstance<T>();
				}
				catch (Exception) {
					return _defaultService;
				}
			}
		}
	}
}