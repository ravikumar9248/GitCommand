using ExploringGitCommand.Assertion;
using NUnit.Framework;

namespace ExploringGitCommand
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			Assert2.IsMultiStepMode =true;
			//Assert.Pass("master");
			Assert2.AssertEqual("fail condition", "a", "b");
			Assert2.AssertEqual("fail condition", "a", "b");
			Assert2.AssertEqual("fail condition", "a", "b");
			Assert2.AssertEqual("fail condition", "a", "b");
			Assert2.AssertEqual("fail condition", "a", "b");
			Assert2.ThrowAllFailures();
		}


		[Test]
		public void Test2()
		{
			Assert2.IsMultiStepMode = true;
			//Assert.Pass("master");
			Assert2.AssertEqual("pass condition", "a", "b");
			Assert2.ThrowAllFailures();
		}
	}
}