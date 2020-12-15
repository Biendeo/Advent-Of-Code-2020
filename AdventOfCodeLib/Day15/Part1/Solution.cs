using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day15.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllText(inputFile).Trim());
		public static int Solve(string input) => Solve(input, 2020);
		public static int Solve(string input, int numTurns) {
			List<int> convertedInput = input.Split(',').Select(x => int.Parse(x)).ToList();
			Dictionary<int, int> numbers = new();

			int lastNumberSpoken = convertedInput[0];
			for (int turn = 2; turn <= numTurns; ++turn) {
				if (turn <= convertedInput.Count) {
					numbers[lastNumberSpoken] = turn - 1;
					lastNumberSpoken = convertedInput[turn - 1];
				} else {
					if (numbers.ContainsKey(lastNumberSpoken)) {
						int lastTurn = numbers[lastNumberSpoken];
						numbers[lastNumberSpoken] = turn - 1;
						lastNumberSpoken = turn - 1 - lastTurn;
					} else {
						numbers[lastNumberSpoken] = turn - 1;
						lastNumberSpoken = 0;
					}
				}
			}

			return lastNumberSpoken;
		}
	}
}
