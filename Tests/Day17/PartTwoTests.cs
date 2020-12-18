using AdventOfCodeLib.Day17.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day17 {
	public class PartTwoTests {
		public const string TestStringOne = @".#.
..#
###";

		[Theory]
		[InlineData(TestStringOne, 848)]
		public void TestCubes(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
