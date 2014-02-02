using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NUnitAddins {
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public class InitializeOnLoadAttribute : Attribute {
		internal static void Configure(AppDomain domain) {
			domain.AssemblyLoad += OnAssemblyLoad;
			foreach (var assembly in domain.GetAssemblies()) {
				InitAssembly(assembly);
			}
		}

		private static void OnAssemblyLoad(object sender, AssemblyLoadEventArgs args) {
			InitAssembly(args.LoadedAssembly);
		}

		private static void InitAssembly(Assembly loadedAssembly) {
			foreach (
				InitializeOnLoadAttribute attr in loadedAssembly.GetCustomAttributes(typeof(InitializeOnLoadAttribute), false)) {
				RuntimeHelpers.RunClassConstructor(attr.Type.TypeHandle);
			}
		}

		private readonly Type _type;

		public InitializeOnLoadAttribute(Type type) {
			_type = type;
		}

		public Type Type {
			get {
				return _type;
			}
		}
	}
}