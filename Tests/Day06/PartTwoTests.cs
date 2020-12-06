using AdventOfCodeLib.Day06.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day06 {
	public class PartTwoTests {
		public const string TestStringOne = @"abc

a
b
c

ab
ac

a
a
a
a

b
";

		[Theory]
		[InlineData(TestStringOne, 6)]
		public void TestSeatID(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
