using AdventOfCodeLib.Day05.Part1;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day05 {
	public class PartOneTests {
		[Theory]
		[InlineData("FBFBBFFRLR", 357)]
		[InlineData("BFFFBBFRRR", 567)]
		[InlineData("FFFBBBFRRR", 119)]
		[InlineData("BBFFBBFRLL", 820)]
		public void TestSeatID(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.GetID(input));
		}
	}
}
