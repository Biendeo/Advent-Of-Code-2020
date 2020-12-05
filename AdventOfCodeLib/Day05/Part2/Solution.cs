using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day05.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			HashSet<int> ids = new(input.Select(i => GetID(i)));
			int min = ids.Min();
			int max = ids.Max();
			return Enumerable.Range(min + 1, max - min - 1).Single(i => !ids.Contains(i));
		}

		public static int GetID(string input) => BinaryPosition(input[..7].Select(i => i == 'F').ToArray()) * 8 + BinaryPosition(input[7..].Select(i => i == 'L').ToArray());

		public static int BinaryPosition(bool[] front) {
			int value = 0;
			for (int i = 0; i < front.Length; ++i) {
				if (!front[i]) value += 1 << (front.Length - i - 1);
			}
			return value;
		}
	}
}
