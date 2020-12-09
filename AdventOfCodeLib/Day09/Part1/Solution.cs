using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day09.Part1 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile), 25);
		public static long Solve(string[] input, int preambleLength) {
			long[] convertedInput = input.Where(s => s.Length > 0).Select(s => long.Parse(s)).ToArray();
			List<long> sums = new();
			for (int i = 0; i < preambleLength; ++i) {
				for (int j = i + 1; j < preambleLength; ++j) {
					sums.Add(convertedInput[i] + convertedInput[j]);
				}
			}
			for (int i = preambleLength; i < convertedInput.Length; ++i) {
				if (!sums.Contains(convertedInput[i])) {
					return convertedInput[i];
				} else {
					sums.RemoveRange(0, preambleLength - 1);
					int index = preambleLength - 2;
					int step = preambleLength - 2;
					while (step > -1) {
						sums.Insert(index, convertedInput[i] + convertedInput[i - step - 1]);
						index += step;
						--step;
					}
				}
			}
			return -1;
		}
	}
}
