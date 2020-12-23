using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCodeLib.Day23.Part1 {
	public static class Solution {
		public static string SolveFromInputFile(string inputFile) => Solve(File.ReadAllText(inputFile).Trim());
		public static string Solve(string input) {
			List<int> cups = input.Select(c => c - '0').ToList();

			RunRounds(cups, 100);

			int oneIndex = cups.IndexOf(1);
			StringBuilder sb = new();
			for (int i = 1; i < cups.Count; ++i) {
				sb.Append(cups[(oneIndex + i) % cups.Count]);
			}

			return sb.ToString();
		}

		public static void RunRounds(List<int> cups, int moves) {
			int currentCup = cups.First();

			for (int move = 0; move < moves; ++move) {
				while (cups.Last() != currentCup) {
					cups.Add(cups.First());
					cups.RemoveAt(0);
				}
				List<int> removedCups = cups.Take(3).ToList();
				cups.RemoveRange(0, 3);

				int destinationCup = currentCup - 1;

				while (!cups.Contains(destinationCup)) {
					--destinationCup;
					if (destinationCup < cups.Min()) {
						destinationCup = cups.Max();
					}
				}

				cups.InsertRange(cups.IndexOf(destinationCup) + 1, removedCups);

				currentCup = cups[(cups.IndexOf(currentCup) + 1) % cups.Count];
			}
		}
	}
}
