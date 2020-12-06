using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day06.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			HashSet<char> currentLetters = new("abcdefghijklmnopqrstuvwxyz");
			int total = 0;
			bool seenMember = false;
			foreach (string line in input) {
				if (line.Length == 0) {
					if (seenMember) {
						total += currentLetters.Count;
					}
					currentLetters.UnionWith("abcdefghijklmnopqrstuvwxyz");
					seenMember = false;
				} else {
					currentLetters.IntersectWith(line);
					seenMember = true;
				}
			}
			return total + (seenMember ? currentLetters.Count : 0);
		}
	}
}
