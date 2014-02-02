using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing.Imaging;
using System.IO;

using NUnit.Core;
using NUnit.Framework;

using OpenQA.Selenium;

namespace NUnitAddins.WebDriver {
	public class WebDriverScreenshotEventListener : EventListener, EventListener2 {
		private readonly string _pathTemplate;
		private readonly string _urlTemplate;
		private readonly ITakesScreenshot _screenshoter;
		private readonly Func<TestResult, bool> _condition;
		private string _runName;

		public WebDriverScreenshotEventListener(
			string pathTemplate,
			string urlTemplate,
			ITakesScreenshot screenshoter,
			Func<TestResult, bool> condition) {
			Contract.Requires(pathTemplate != null);
			Contract.Requires(urlTemplate != null);
			Contract.Requires(screenshoter != null);
			Contract.Requires(condition != null);

			_pathTemplate = pathTemplate;
			_urlTemplate = urlTemplate;
			_screenshoter = screenshoter;
			_condition = condition;
		}

		public void RunStarted(string name, int testCount) {
			_runName = name;
		}

		public void AfterTest(TestResult result, TestDetails details) {
			if (!result.Test.IsSuite && _condition(result)) {
				MakeScreenshot(result);
				AddUrlToProperties(result);
			}
		}

		private void AddUrlToProperties(TestResult result) {
			var url = Format(_urlTemplate, result);
			result.Test.Properties["Screenshot"] = url;
		}

		private string Format(string template, TestResult result) {
			return template
				.Replace("{RunName}", _runName)
				.Replace("{TestName}", ReplaceInvalidChars(result.Test.TestName.ToString(), Path.GetInvalidFileNameChars()));
		}

		private void MakeScreenshot(TestResult result) {
			var path = GetPath(result);

			var screenshot = _screenshoter.GetScreenshot();

			if (File.Exists(path)) {
				File.Delete(path);
			}

			screenshot.SaveAsFile(path, ImageFormat.Png);
		}

		private string GetPath(TestResult result) {
			var path = Format(_pathTemplate, result);
			Logger.Log(path);

			var directory = Path.GetDirectoryName(path);
			if (directory != null) {
				Directory.CreateDirectory(directory);
			}

			return path;
		}

		private string ReplaceInvalidChars(string fileName, IEnumerable<char> invalidChars) {
			var result = fileName;
			foreach (var invalidChar in invalidChars) {
				result = result.Replace(invalidChar, '_');
			}

			return result;
		}

		public void BeforeTest(TestResult result, TestDetails details) {
		}

		public void RunFinished(TestResult result) {
		}

		public void RunFinished(Exception exception) {
		}

		public void TestStarted(TestName testName) {
		}

		public void TestFinished(TestResult result) {
		}

		public void SuiteStarted(TestName testName) {
		}

		public void SuiteFinished(TestResult result) {
		}

		public void UnhandledException(Exception exception) {
		}

		public void TestOutput(TestOutput testOutput) {
		}
	}
}