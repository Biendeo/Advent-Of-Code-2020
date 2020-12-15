using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day15.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllText(inputFile).Trim());
		public static int Solve(string input) => Part1.Solution.Solve(input, 30000000);
	}
}
