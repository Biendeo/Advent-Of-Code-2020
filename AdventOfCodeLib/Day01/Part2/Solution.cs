using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day01.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) {
			return Solve(new List<int>(File.ReadAllLines(inputFile).Select(l => int.Parse(l))));
		}

		public static int Solve(List<int> values) {
			var valuesSet = new HashSet<int>(values);
			foreach (int value1 in values) {
				foreach (int value2 in values) {
					if (value1 != value2) {
						if (valuesSet.Contains(2020 - value1 - value2)) {
							return (2020 - value1 - value2) * value1 * value2;
						}
					}
				}
			}
			return -1;
		}
	}
}
