using AdventOfCodeLib.Day01.Part2;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day01 {
	public class PartTwoTests {
		[Theory]
		[InlineData("1721,979,366,299,675,1456", 241861950)]
		public void TestProduct(string values, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(new List<int>(values.Split(",").Select(c => int.Parse(c)))));
		}
	}
}
