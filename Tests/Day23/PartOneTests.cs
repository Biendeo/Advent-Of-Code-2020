using AdventOfCodeLib.Day23.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day23 {
	public class PartOneTests {
		[Theory]
		[InlineData("389125467", "67384529")]
		public void TestScore(string input, string expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input));
		}
	}
}
