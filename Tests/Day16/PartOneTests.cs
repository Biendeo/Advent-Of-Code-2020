using AdventOfCodeLib.Day16.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day16 {
	public class PartOneTests {
		public const string TestStringOne = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

		[Theory]
		[InlineData(TestStringOne, 71)]
		public void TestErrorRate(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
