using System;

using Microsoft.Practices.ServiceLocation;

using NUnit.Core;
using NUnit.Framework;

namespace NUnitAddins.Tests {
	[TestFixture]
	public class MyTestFixture {
		[Test]
		[Category("hello")]
		public void MyTest() {
			Console.WriteLine("Its my test");
			Console.WriteLine(ServiceLocator.Current.GetInstance<EventListener>());
		}
	}
}