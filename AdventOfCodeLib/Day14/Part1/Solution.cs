using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day14.Part1 {
	public static class Solution {
		public static ulong SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static ulong Solve(string[] input) {
			input = input.Where(s => s.Length > 0).ToArray();
			string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
			Dictionary<int, ulong> memory = new();
			foreach (string s in input) {
				if (s.StartsWith("mask")) {
					mask = s[7..];
				} else if (s.StartsWith("mem")) {
					int address = int.Parse(s.Split('[')[1].Split(']')[0]);
					ulong value = ulong.Parse(s.Split('=')[1][1..]);
					for (int i = 0; i < 36; ++i) {
						if (mask[36 - i - 1] == '0') {
							value &= (ulong.MaxValue ^ (1ul << i));
						} else if (mask[36 - i - 1] == '1') {
							value |= (1ul << i);
						}
					}
					memory[address] = value;
				}
			}
			ulong sum = 0ul;
			foreach (ulong x in memory.Values) {
				sum += x;
			}
			return sum;
		}
	}
}
