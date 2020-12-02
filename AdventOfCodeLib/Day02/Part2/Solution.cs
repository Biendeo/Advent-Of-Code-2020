using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day02.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) {
			return Solve(PasswordPolicy.FromInputLines(File.ReadAllLines(inputFile)));
		}

		public static int Solve(List<PasswordPolicy> policies) {
			return policies.Count(p => p.IsValidPartTwo);
		}
	}
}
