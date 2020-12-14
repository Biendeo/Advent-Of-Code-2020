using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day14.Part2 {
	public static class Solution {
		public static ulong SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static ulong Solve(string[] input) {
			input = input.Where(s => s.Length > 0).ToArray();
			string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
			Dictionary<ulong, ulong> memory = new();
			foreach (string s in input) {
				if (s.StartsWith("mask")) {
					mask = s[7..];
				} else if (s.StartsWith("mem")) {
					ulong baseAddress = ulong.Parse(s.Split('[')[1].Split(']')[0]);
					ulong value = ulong.Parse(s.Split('=')[1][1..]);

					for (int i = 0; i < 36; ++i) {
						if (mask[36 - i - 1] == '1') {
							baseAddress |= (1ul << i);
						} else if (mask[36 - i - 1] == 'X') {
							baseAddress &= (ulong.MaxValue ^ (1ul << i));
						}
					}

					foreach (ulong maskOffset in GetPermutationsOfMask(mask)) {
						memory[baseAddress + maskOffset] = value;
					}
				}
			}
			ulong sum = 0ul;
			foreach (ulong x in memory.Values) {
				sum += x;
			}
			return sum;
		}

		private static List<ulong> GetPermutationsOfMask(string mask) {
			List<ulong> permutations = new();
			permutations.Add(0ul);
			for (int i = 0; i < 36; ++i) {
				if (mask[36 - i - 1] == 'X') {
					int count = permutations.Count;
					for (int j = 0; j < count; ++j) {
						permutations.Add(permutations[j] + (1ul << i));
					}
				}
			}
			return permutations;
		}
	}
}
