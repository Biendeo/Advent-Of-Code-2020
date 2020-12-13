using AdventOfCodeLib.Day13.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day13 {
	public class PartOneTests {
		public const string TestStringOne = @"939
7,13,x,x,59,x,31,19";

		[Theory]
		[InlineData(TestStringOne, 295)]
		public void TestMinutes(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
