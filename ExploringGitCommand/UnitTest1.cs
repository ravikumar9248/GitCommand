using System;
using System.Collections.Generic;
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

		[Test]
		public void Test3()
		{
			int[] array = {1,3,-5,7,8,20,-40,6 };
			
			int pari1 = 0;
			int pari2=1;
			int count = array[0]+array[1];

			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					if(i==j)
						continue;

					int sum = array[i] + array[j];

					if (Math.Abs(count) > Math.Abs(sum))
					{
						count = sum;
						pari1 = i;
						pari2 = j;
					}
				}
			}

			Console.WriteLine(array[pari1] +" "+ array[pari2]);
		}
	}
}