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
			int startIndex = -1;
			int endIndex = -1;
			bool found = false;
			while (!found) {
				++startIndex;
				long sum = 0;
				endIndex = startIndex - 1;
				while (sum < invalidNumber) {
					++endIndex;
					sum += convertedInput[endIndex];
				}
				if (sum == invalidNumber) {
					found = true;
				}
			}
			long min = long.MaxValue;
			long max = long.MinValue;
			foreach (long x in convertedInput[startIndex..(endIndex + 1)]) {
				min = Math.Min(min, x);
				max = Math.Max(max, x);
			}
			return min + max;
		}
	}
}
