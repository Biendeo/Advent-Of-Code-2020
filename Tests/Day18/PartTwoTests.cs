using AdventOfCodeLib.Day18.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day18 {
	public class PartTwoTests {
		[Theory]
		[InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
		[InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
		[InlineData("2 * 3 + (4 * 5)", 46)]
		[InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
		[InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
		[InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
		public void TestEquation(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
