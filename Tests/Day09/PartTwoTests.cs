using AdventOfCodeLib.Day09.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day09 {
	public class PartTwoTests {
		public const string TestStringOne = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576
";

		[Theory]
		[InlineData(TestStringOne, 62)]
		public void TestInvalidNumber(string input, long expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine), 5));
		}
	}
}
