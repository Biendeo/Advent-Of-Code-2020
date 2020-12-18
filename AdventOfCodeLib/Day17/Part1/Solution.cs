using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day17.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			HashSet<Grid3> grid = new();

			for (int y = 0; y < input.Length; ++y) {
				for (int x = 0; x < input[y].Length; ++x) {
					if (input[y][x] == '#') {
						grid.Add(new Grid3 {
							X = x,
							Y = y,
							Z = 0
						});
					}
				}
			}

			for (int round = 0; round < 6; ++round) {
				HashSet<Grid3> newGrid = new();

				foreach (var g in grid.SelectMany(g => g.Neighbours).Distinct()) {
					int neighbourCount = g.Neighbours.Where(n => grid.Contains(n)).Count();
					if (grid.Contains(g) && (neighbourCount == 2 || neighbourCount == 3)) {
						newGrid.Add(g);
					} else if (!grid.Contains(g) && neighbourCount == 3) {
						newGrid.Add(g);
					}
				}

				grid = newGrid;
			}

			return grid.Count;
		}
	}
}
