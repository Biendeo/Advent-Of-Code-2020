using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day01.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) {
			return Solve(new List<int>(File.ReadAllLines(inputFile).Select(l => int.Parse(l))));
		}

		public static int Solve(List<int> values) {
			var valuesSet = new HashSet<int>(values);
			foreach (int value in values) {
				if (valuesSet.Contains(2020 - value)) {
					return value * (2020 - value);
				}
			}
			return -1;
		}
	}
}
