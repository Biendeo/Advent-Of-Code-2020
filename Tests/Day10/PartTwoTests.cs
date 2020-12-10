using AdventOfCodeLib.Day10.Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day10 {
	public class PartTwoTests {
		public const string TestStringOne = @"16
10
15
5
1
11
7
19
6
12
4";
		public const string TestStringTwo = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

		[Theory]
		[InlineData(TestStringOne, 8)]
		[InlineData(TestStringTwo, 19208)]
		public void TestJoltages(string input, long expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(input.Split(Environment.NewLine)));
		}
	}
}
