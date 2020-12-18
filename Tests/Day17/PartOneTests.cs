using AdventOfCodeLib.Day17.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day17 {
	public class PartOneTests {
		public const string TestStringOne = @".#.
..#
###";

		[Theory]
		[InlineData(TestStringOne, 112)]
		public void TestCubes(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
