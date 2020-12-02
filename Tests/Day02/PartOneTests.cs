using AdventOfCodeLib.Day02;
using AdventOfCodeLib.Day02.Part1;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day02 {
	public class PartOneTests {
		[Theory]
		[InlineData("1-3 a: abcde,1-3 b: cdefg,2-9 c: ccccccccc", 2)]
		public void TestProduct(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(PasswordPolicy.FromInputLines(input.Split(','))));
		}
	}
}
