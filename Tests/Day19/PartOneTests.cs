using AdventOfCodeLib.Day19.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day19 {
	public class PartOneTests {
		[Theory]
		[InlineData("0: 4 1 5\n1: 2 3 | 3 2\n2: 4 4 | 5 5\n3: 4 5 | 5 4\n4: \"a\"\n5: \"b\"\n\nababbb\nbababa\nabbbab\naaabbb\naaaabbb", 2)]
		public void TestMatches(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split('\n')));
		}
	}
}
