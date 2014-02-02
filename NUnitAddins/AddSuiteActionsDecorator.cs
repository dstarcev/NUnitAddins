using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;

using NUnit.Core;
using NUnit.Core.Extensibility;
using NUnit.Framework;

namespace NUnitAddins {
	internal class AddSuiteActionsDecorator : ITestDecorator {
		private static readonly FieldInfo _actionsField = typeof(TestSuite).GetField(
			"actions", BindingFlags.Instance | BindingFlags.NonPublic);

		private readonly ITestAction _action;

		public AddSuiteActionsDecorator(ITestAction action) {
			Contract.Requires(action != null);

			_action = action;
		}

		public Test Decorate(Test test, MemberInfo member) {
			Logger.Log("ololo " + test);
			var testSuite = test as TestSuite;
			if (testSuite != null) {
				AddActions(testSuite);
			}

			return test;
		}

		private void AddActions(TestSuite suite) {
			var currentActions = _actionsField.GetValue(suite) as TestAction[];

			var newActions = new List<TestAction>();
			if (currentActions != null) {
				newActions.AddRange(currentActions);
			}

			newActions.Add(new TestAction(_action));

			_actionsField.SetValue(suite, newActions.ToArray());
		}
	}
}