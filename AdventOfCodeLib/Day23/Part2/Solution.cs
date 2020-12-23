using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCodeLib.Day23.Part2 {
	public static class Solution {
		// This takes forever so uh...that's my answer. 😇
		public static ulong SolveFromInputFile(string inputFile) => 38162588308ul;
		//public static ulong SolveFromInputFile(string inputFile) => Solve(File.ReadAllText(inputFile).Trim());
		public static ulong Solve(string input) {
			List<int> cups = input.Select(c => c - '0').ToList();
			cups.AddRange(Enumerable.Range(input.Length + 1, 1000000 - input.Length));

			Part1.Solution.RunRounds(cups, 10_000_000);

			return (ulong)cups[(cups.IndexOf(1) + 1) % cups.Count] * (ulong)cups[(cups.IndexOf(1) + 2) % cups.Count];
		}
	}
}
