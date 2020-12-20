using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day20.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			Dictionary<ulong, bool[,]> tiles = new();
			for (int i = 0; i < input.Length; ++i) {
				if (input[i].StartsWith("Tile")) {
					ulong id = ulong.Parse(input[i][5..^1]);
					bool[,] map = new bool[10, 10];
					for (int x = 0; x < 10; ++x) {
						for (int y = 0; y < 10; ++y) {
							map[x, y] = input[i + y + 1][x] == '#';
						}
					}
					tiles.Add(id, map);
					i += 10;
				}
			}
			int squareAxis = (int)Math.Sqrt(tiles.Count);
			ulong[,] gridIndicies = new ulong[squareAxis, squareAxis];
			bool[,][,] grid = new bool[squareAxis, squareAxis][,];
			Part1.Solution.FindGrid(0, 0, squareAxis, 10, tiles, gridIndicies, grid);
			bool[,] finalisedGrid = new bool[squareAxis * 8, squareAxis * 8];
			int hashCount = 0;
			for (int a = 0; a < squareAxis; ++a) {
				for (int b = 0; b < squareAxis; ++b) {
					for (int x = 1; x < 9; ++x) {
						for (int y = 1; y < 9; ++y) {
							finalisedGrid[a * 8 + (x - 1), b * 8 + (y - 1)] = grid[a, b][x, y];
							if (finalisedGrid[a * 8 + (x - 1), b * 8 + (y - 1)]) {
								++hashCount;
							}
						}
					}
				}
			}
			bool[,] monsterShape = new bool[20, 3];
			// Judge this translation of the monster.
			for (int x = 0; x < 20; ++x) {
				for (int y = 0; y < 3; ++y) {
					monsterShape[x, y] =
						y == 0 && x == 18 ||
						y == 1 && x == 0  ||
						y == 1 && x == 5  ||
						y == 1 && x == 6  ||
						y == 1 && x == 11 ||
						y == 1 && x == 12 ||
						y == 1 && x == 17 ||
						y == 1 && x == 18 ||
						y == 1 && x == 19 ||
						y == 2 && x == 1  ||
						y == 2 && x == 4  ||
						y == 2 && x == 7  ||
						y == 2 && x == 10 ||
						y == 2 && x == 13 ||
						y == 2 && x == 16;
				}
			}
			List<bool[,]> monsterVariants = new(new[] { monsterShape });
			for (int i = 0; i < 3; ++i) {
				monsterVariants.Add(Part1.Solution.Rotate(monsterVariants.Last()));
			}
			monsterVariants.Add(Part1.Solution.Mirror(monsterVariants.Last()));
			for (int i = 0; i < 3; ++i) {
				monsterVariants.Add(Part1.Solution.Rotate(monsterVariants.Last()));
			}
			int monsterCount = 0;
			foreach (bool[,] variant in monsterVariants) {
				for (int x = 0; x < squareAxis * 8 - variant.GetLength(0) + 1; ++x) {
					for (int y = 0; y < squareAxis * 8 - variant.GetLength(1) + 1; ++y) {
						bool fits = true;
						for (int a = 0; a < variant.GetLength(0) && fits; ++a) {
							for (int b = 0; b < variant.GetLength(1) && fits; ++b) {
								if (variant[a, b] && !finalisedGrid[x + a, y + b]) {
									fits = false;
								}
							}
						}
						if (fits) {
							++monsterCount;
						}
					}
				}
			}
			return hashCount - monsterCount * 15;
		}
	}
}
