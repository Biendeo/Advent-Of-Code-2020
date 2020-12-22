using AdventOfCodeLib.Day22.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day22 {
	public class PartTwoTests {
		public const string TestStringOne = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

		[Theory]
		[InlineData(TestStringOne, 291)]
		public void TestScore(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
