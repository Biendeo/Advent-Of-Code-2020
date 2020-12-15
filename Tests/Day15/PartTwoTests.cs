using AdventOfCodeLib.Day15.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day15 {
	public class PartTwoTests {
		[Theory]
		[InlineData("0,3,6", 175594)]
		[InlineData("1,3,2", 2578)]
		[InlineData("2,1,3", 3544142)]
		[InlineData("1,2,3", 261214)]
		[InlineData("2,3,1", 6895259)]
		[InlineData("3,2,1", 18)]
		[InlineData("3,1,2", 362)]
		public void TestNumberSpoken(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input));
		}
	}
}
