using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day04.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllText(inputFile));
		public static int Solve(string input) => Passport.Solve(input, p => p.IsValidPartOne);
	}
}
