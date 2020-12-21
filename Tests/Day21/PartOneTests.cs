using AdventOfCodeLib.Day21.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day21 {
	public class PartOneTests {
		public const string TestStringOne = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";

		[Theory]
		[InlineData(TestStringOne, 5)]
		public void TestAllergens(string input, int expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
