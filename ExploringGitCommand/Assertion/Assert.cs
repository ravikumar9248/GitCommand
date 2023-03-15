using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ExploringGitCommand.Assertion
{
	public static class Assert2
	{
		public static bool IsMultiStepMode = false;

		private static ConcurrentQueue<Exception>? testFailures = new();

		public static bool HasFailures;

		public static void ThrowAllFailures()
		{
			HasFailures = testFailures.Any();

			if (!HasFailures)
				return;

			string message = string.Join(Environment.NewLine, testFailures.Select(x => x.Message));

			try
			{
				Assert.Fail(message);
			}
			finally
			{
				testFailures = new ConcurrentQueue<Exception>();
				IsMultiStepMode = false;
				ClearNUnitAssertions();
			}
		}

		public static void ClearNUnitAssertions()
		{
			//((IList<AssertionResult>)TestContext.CurrentContext.Result.Assertions).Clear();
		}

		private static bool CheckAndLogResults(string description, bool condition)
		{
			if (condition)
				return true;

			if (IsMultiStepMode)
			{
				try
				{
					throw new Exception(description);
				}
				catch (Exception e)
				{
					testFailures.Enqueue(e);
				}
			}
			else
			{
				Assert.Fail(description);
			}
			return false;
		}

		public static bool AssertEqual(string comparedPropertyName, string expected, string actual)
		{
			bool result = expected.Equals(actual);
			return CheckAndLogResults(comparedPropertyName, result);
		}
	}
}
