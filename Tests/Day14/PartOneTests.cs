using AdventOfCodeLib.Day14.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day14 {
	public class PartOneTests {
		public const string TestStringOne = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";

		[Theory]
		[InlineData(TestStringOne, 165)]
		public void TestBitmask(string input, ulong expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
