using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day12.Part1 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static long Solve(string[] input) {
			int x = 0;
			int y = 0;
			Direction d = Direction.East;
			foreach (string s in input.Where(s => s.Length > 0)) {
				int magnitude = int.Parse(s[1..]);
				if (s[0] == 'N' || (s[0] == 'F' && d == Direction.North)) {
					y += magnitude;
				} else if (s[0] == 'E' || (s[0] == 'F' && d == Direction.East)) {
					x += magnitude;
				} else if (s[0] == 'S' || (s[0] == 'F' && d == Direction.South)) {
					y -= magnitude;
				} else if (s[0] == 'W' || (s[0] == 'F' && d == Direction.West)) {
					x -= magnitude;
				} else if (s[0] == 'L') {
					for (; magnitude > 0; magnitude -= 90) {
						d = d.Left();
					}
				} else if (s[0] == 'R') {
					for (; magnitude > 0; magnitude -= 90) {
						d = d.Right();
					}
				}
			}
			return Math.Abs(x) + Math.Abs(y);
		}
	}
}
