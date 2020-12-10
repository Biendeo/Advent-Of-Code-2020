using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day10.Part1 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static long Solve(string[] input) {
			List<int> convertedInput = new(input.Where(s => s.Length > 0).Select(s => int.Parse(s)).OrderBy(x => x));
			convertedInput.Insert(0, 0);
			int oneSteps = 0;
			int threeSteps = 1;
			for (int i = 1; i < convertedInput.Count; ++i) {
				if (convertedInput[i] - convertedInput[i - 1] == 1) {
					++oneSteps;
				} else if (convertedInput[i] - convertedInput[i - 1] == 3) {
					++threeSteps;
				}
			}
			return oneSteps * threeSteps;
		}
	}
}
