using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCodeLib.Day24.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) => DetermineFlippedTiles(input).Count;

		public static HashSet<(int X, int Y)> DetermineFlippedTiles(string[] input) {
			input = input.Where(s => !string.IsNullOrEmpty(s)).ToArray();

			List<List<Direction>> directions = new();
			foreach (string s in input) {
				directions.Add(new());
				for (int i = 0; i < s.Length; ++i) {
					if (s[i] == 's') {
						++i;
						if (s[i] == 'e') {
							directions.Last().Add(Direction.SouthEast);
						} else if (s[i] == 'w') {
							directions.Last().Add(Direction.SouthWest);
						}
					} else if (s[i] == 'n') {
						++i;
						if (s[i] == 'e') {
							directions.Last().Add(Direction.NorthEast);
						} else if (s[i] == 'w') {
							directions.Last().Add(Direction.NorthWest);
						}
					} else if (s[i] == 'e') {
						directions.Last().Add(Direction.East);
					} else if (s[i] == 'w') {
						directions.Last().Add(Direction.West);
					}
				}
			}

			HashSet<(int X, int Y)> flippedTiles = new();

			foreach (var directionList in directions) {
				int x = 0;
				int y = 0;
				foreach (var direction in directionList) {
					(x, y) = direction.Move(x, y, 1);
				}
				if (flippedTiles.Contains((x, y))) {
					flippedTiles.Remove((x, y));
				} else {
					flippedTiles.Add((x, y));
				}
			}

			return flippedTiles;
		}
	}
}
