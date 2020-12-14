using AdventOfCodeLib.Day14.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day14 {
	public class PartTwoTests {
		public const string TestStringOne = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";

		[Theory]
		[InlineData(TestStringOne, 208)]
		public void TestBitmask(string input, ulong expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
