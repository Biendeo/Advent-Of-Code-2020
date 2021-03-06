﻿using AdventOfCodeLib.Day08.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day08 {
	public class PartOneTests {
		public const string TestStringOne = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6
";

		[Theory]
		[InlineData(TestStringOne, 5)]
		public void TestAccumulator(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
