using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day09.Part2 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile), 25);
		public static long Solve(string[] input, int preambleLength) {
			long invalidNumber = Part1.Solution.Solve(input, preambleLength);
			long[] convertedInput = input.Where(s => s.Length > 0).Select(s => long.Parse(s)).ToArray();
			for (int startIndex = 0; startIndex < convertedInput.Length; ++startIndex) {
				long sum = 0;
				long min = long.MaxValue;
				long max = long.MinValue;
				long endIndex = startIndex - 1;
				while (sum < invalidNumber && endIndex < convertedInput.Length) {
					++endIndex;
					sum += convertedInput[endIndex];
					min = Math.Min(min, convertedInput[endIndex]);
					max = Math.Max(max, convertedInput[endIndex]);
				}
				if (sum == invalidNumber) {
					return min + max;
				}
			}
			return -1;
		}
	}
}
