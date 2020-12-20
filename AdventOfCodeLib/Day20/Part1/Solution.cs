using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day20.Part1 {
	public static class Solution {
		public static ulong SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static ulong Solve(string[] input) {
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
			FindGrid(0, 0, squareAxis, 10, tiles, gridIndicies, grid);
			return gridIndicies[0, 0] * gridIndicies[squareAxis - 1, 0] * gridIndicies[0, squareAxis - 1] * gridIndicies[squareAxis - 1, squareAxis -1];
		}

		internal static bool FindGrid(int x, int y, int squareAxisLength, int tileSize, Dictionary<ulong, bool[,]> tiles, ulong[,] gridIndicies, bool[,][,] grid) {
			if (y >= squareAxisLength) {
				return true;
			}
			HashSet<ulong> existingTiles = new();
			int nextX = (x + 1) % squareAxisLength;
			int nextY = nextX == 0 ? y + 1 : y;
			for (int b = 0; b <= y; ++b) {
				for (int a = 0; a < (b == y ? x : squareAxisLength); ++a) {
					existingTiles.Add(gridIndicies[a, b]);
				}
			}
			foreach (var tile in tiles) {
				if (!existingTiles.Contains(tile.Key)) {
					gridIndicies[x, y] = tile.Key;
					List<bool[,]> variants = new(new[] { tile.Value });
					for (int i = 0; i < 3; ++i) {
						variants.Add(Rotate(variants.Last()));
					}
					variants.Add(Mirror(variants.Last()));
					for (int i = 0; i < 3; ++i) {
						variants.Add(Rotate(variants.Last()));
					}
					foreach (bool[,] variant in variants) {
						grid[x, y] = variant;
						bool fits = true;
						// Check top
						if (y > 0) {
							for (int a = 0; a < tileSize; ++a) {
								fits &= grid[x, y][a, 0] == grid[x, y - 1][a, tileSize - 1];
							}
						}
						// Check left
						if (fits && x > 0) {
							for (int b = 0; b < tileSize; ++b) {
								fits &= grid[x, y][0, b] == grid[x - 1, y][tileSize - 1, b];
							}
						}
						if (fits) {
							if (FindGrid(nextX, nextY, squareAxisLength, tileSize, tiles, gridIndicies, grid)) {
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		internal static bool[,] Mirror(bool[,] grid) {
			bool[,] r = new bool[grid.GetLength(0), grid.GetLength(1)];
			for (int x = 0; x < grid.GetLength(0); ++x) {
				for (int y = 0; y < grid.GetLength(1); ++y) {
					r[x, y] = grid[grid.GetLength(0) - x - 1, y];
				}
			}
			return r;
		}

		internal static bool[,] Rotate(bool[,] grid) {
			bool[,] r = new bool[grid.GetLength(1), grid.GetLength(0)];
			for (int x = 0; x < grid.GetLength(1); ++x) {
				for (int y = 0; y < grid.GetLength(0); ++y) {
					r[x, y] = grid[grid.GetLength(0) - y - 1, x];
				}
			}
			return r;
		}
	}
}
