using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PriceCounter;
using System.Collections.Generic;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			List<double> list = new List<double>() { 400, 600};

			double actual = Price.Count(list);
			double expected = 1000;
			Assert.AreEqual(actual, expected);	
		}

		[TestMethod]
		public void TestMethod2()
		{
			List<double> list = new List<double>() { 200, 250 };

			double actual = Price.Count(list);
			double expected = 450;
			Assert.IsTrue(actual == expected);
		}

		[TestMethod]
		public void TestMethod3()
		{
			List<double> list = new List<double>() { 100, 150 };

			double actual = Price.Count(list);
			double expected = 350;
			Assert.IsFalse(actual == expected);
		}
	}
}
