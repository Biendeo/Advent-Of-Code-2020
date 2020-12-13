using AdventOfCodeLib.Day13.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day13 {
	public class PartTwoTests {

		[Theory]
		[InlineData("0\n7,13,x,x,59,x,31,19", 1068781)]
		[InlineData("0\n17,x,13,19", 3417)]
		[InlineData("0\n67,7,59,61", 754018)]
		[InlineData("0\n67,x,7,59,61", 779210)]
		[InlineData("0\n67,7,x,59,61", 1261476)]
		[InlineData("0\n1789,37,47,1889", 1202161486)]
		public void TestMinutes(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split('\n')));
		}
	}
}
