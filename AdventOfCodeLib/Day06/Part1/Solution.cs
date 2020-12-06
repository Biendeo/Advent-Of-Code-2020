using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day06.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			HashSet<char> currentLetters = new();
			int total = 0;
			foreach (string line in input) {
				if (line.Length == 0) {
					total += currentLetters.Count;
					currentLetters.Clear();
				} else {
					currentLetters.UnionWith(line);
				}
			}
			return total + currentLetters.Count;
		}
	}
}
