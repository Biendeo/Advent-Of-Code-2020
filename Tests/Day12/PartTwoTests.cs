using AdventOfCodeLib.Day12.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day12 {
	public class PartTwoTests {
		public const string TestStringOne = @"F10
N3
F7
R90
F11";

		[Theory]
		[InlineData(TestStringOne, 286)]
		public void TestNavigation(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
