using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day12.Part2 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static long Solve(string[] input) {
			int x = 0;
			int y = 0;
			int waypointX = 10;
			int waypointY = 1;
			foreach (string s in input.Where(s => s.Length > 0)) {
				int magnitude = int.Parse(s[1..]);
				if (s[0] == 'F') {
					x += waypointX * magnitude;
					y += waypointY * magnitude;
				}
				if (s[0] == 'N') {
					waypointY += magnitude;
				} else if (s[0] == 'E') {
					waypointX += magnitude;
				} else if (s[0] == 'S') {
					waypointY -= magnitude;
				} else if (s[0] == 'W') {
					waypointX -= magnitude;
				} else if (s[0] == 'L') {
					for (; magnitude > 0; magnitude -= 90) {
						int temp = waypointX;
						waypointX = -waypointY;
						waypointY = temp;
					}
				} else if (s[0] == 'R') {
					for (; magnitude > 0; magnitude -= 90) {
						int temp = waypointX;
						waypointX = waypointY;
						waypointY = -temp;
					}
				}
			}
			return Math.Abs(x) + Math.Abs(y);
		}
	}
}
