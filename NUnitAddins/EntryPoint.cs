using System;

using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NUnitAddins {
	[NUnitAddin]
	public class EntryPoint : IAddin {
		private static bool _installed;
		public bool Install(IExtensionHost host) {
			if (_installed) {
				return false;
			}

			InitializeOnLoadAttribute.Configure(AppDomain.CurrentDomain);
			InstallExtensions(host, "SuiteBuilders", new LocatedSuiteBuilder(new NullSuiteBuilder()));
			InstallExtensions(host, "TestCaseBuilders", new LocatedTestCaseBuilder(new NullTestCaseBuilder2()));
			InstallExtensions(host, "TestCaseBuilders", new LocatedTestCaseBuilder2(new NullTestCaseBuilder2()));
			InstallExtensions(host, "TestCaseProviders", new LocatedTestCaseProvider(new NullTestCaseProvider2()));
			InstallExtensions(host, "TestCaseProviders", new LocatedTestCaseProvider2(new NullTestCaseProvider2()));
			InstallExtensions(host, "TestDecorators", new LocatedTestDecorator(new NullTestDecorator()));
			InstallExtensions(host, "DataPointProviders", new LocatedDataPointProvider(new NullDataPointProvider()));

			var listener = new LocatedEventListener(new NullListener());
			var listener2 = new LocatedEventListener2(new NullListener2());

			InstallExtensions(host, "EventListeners", listener);
			
			if (ResharperRunnerUsed) {
				InstallExtensions(host, "TestDecorators", new AddListenerDecorator(listener));
			}

			InstallExtensions(host, "TestDecorators", new AddSuiteActionsDecorator(new EventListener2Action(listener2)));

			_installed = true;
			return true;
		}

		protected virtual bool ResharperRunnerUsed {
			get {
				return AppDomain.CurrentDomain.FriendlyName.StartsWith("IsolatedAppDomainHost");
			}
		}

		private void InstallExtensions<T>(IExtensionHost host, string pointName, T extension) {
			var point = host.GetExtensionPoint(pointName);
			if (point != null) {
				point.Install(extension);
			}
		}
	}
}