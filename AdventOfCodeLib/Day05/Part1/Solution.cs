using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day05.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) => input.Max(i => GetID(i));

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
