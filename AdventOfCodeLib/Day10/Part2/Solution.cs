using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AdventOfCodeLib.Day10.Part2 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static long Solve(string[] input) {
			HashSet<int> convertedInput = new(input.Where(s => s.Length > 0).Select(s => int.Parse(s)));
			int endValue = convertedInput.Max() + 3;
			convertedInput.Add(endValue);
			long[] permutationsToValue = new long[endValue + 1];
			for (int i = 0; i < endValue + 1; ++i) {
				permutationsToValue[i] = 0;
			}
			permutationsToValue[0] = 1;
			for (int i = 0; i < endValue + 1; ++i) {
				if (convertedInput.Contains(i)) {
					for (int j = Math.Max(0, i - 3); j < i; ++j) {
						permutationsToValue[i] += permutationsToValue[j];
					}
				}
			}
			return permutationsToValue[endValue];
		}
	}
}
