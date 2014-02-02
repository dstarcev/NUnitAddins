using System;
using System.IO;

namespace NUnitAddins {
	public static class Logger {
		public static void Log(object message) {
#if DEBUG 
			File.AppendAllLines("C:\\nunit-log.txt", new string[] { DateTime.Now + " " + message });
#endif
		}
	}
}