using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day11.Part1 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			List<List<GridTile>> grid = input.Select(r => r.Select(c => GridTileExtensions.CharToGrid(c)).ToList()).ToList();
			List<List<GridTile>> newGrid = null;
			int rounds = 0;
			int numberOfChanges = -1;
			while (numberOfChanges != 0) {
				++rounds;
				numberOfChanges = 0;
				newGrid = grid.Clone2DList();
				Enumerable.Range(0, grid.Count).AsParallel().ForAll(y => {
					for (int x = 0; x < grid[y].Count; ++x) {
						if (grid[y][x] != GridTile.Floor) {
							int occupiedSeatsNeighbouring = 0;
							foreach (int yOffset in new[] { -1, 0, 1 }) {
								foreach (int xOffset in new[] { -1, 0, 1 }) {
									if (x + xOffset >= 0 && x + xOffset < grid[y].Count && y + yOffset >= 0 && y + yOffset < grid.Count && (xOffset != 0 || yOffset != 0)) {
										if (grid[y + yOffset][x + xOffset] == GridTile.OccupiedSeat) {
											++occupiedSeatsNeighbouring;
										}
									}
								}
							}
							if (grid[y][x] == GridTile.EmptySeat && occupiedSeatsNeighbouring == 0) {
								newGrid[y][x] = GridTile.OccupiedSeat;
								++numberOfChanges;
							} else if (grid[y][x] == GridTile.OccupiedSeat && occupiedSeatsNeighbouring >= 4) {
								newGrid[y][x] = GridTile.EmptySeat;
								++numberOfChanges;
							}
						}
					}
				});
				grid = newGrid;
			}

			return grid.Sum(r => r.Sum(c => c == GridTile.OccupiedSeat ? 1 : 0));
		}

		public static List<List<T>> Clone2DList<T>(this List<List<T>> l) {
			return new List<List<T>>(l.Select(r => new List<T>(r)));
		}
	}
}
