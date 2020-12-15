using AdventOfCodeLib.Day15.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day15 {
	public class PartOneTests {
		[Theory]
		[InlineData("0,3,6", 436)]
		[InlineData("1,3,2", 1)]
		[InlineData("2,1,3", 10)]
		[InlineData("1,2,3", 27)]
		[InlineData("2,3,1", 78)]
		[InlineData("3,2,1", 438)]
		[InlineData("3,1,2", 1836)]
		public void TestNumberSpoken(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input));
		}
	}
}
