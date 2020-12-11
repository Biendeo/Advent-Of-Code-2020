using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day11.Part2 {
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
				for (int y = 0; y < grid.Count; ++y) {
					for (int x = 0; x < grid[y].Count; ++x) {
						if (grid[y][x] != GridTile.Floor) {
							int occupiedSeatsNeighbouring = 0;
							foreach (var func in new Func<int, int, (int x, int y)>[] {
								(x, y) => (x - 1, y - 1),
								(x, y) => (x, y - 1),
								(x, y) => (x + 1, y - 1),
								(x, y) => (x - 1, y),
								(x, y) => (x + 1, y),
								(x, y) => (x - 1, y + 1),
								(x, y) => (x, y + 1),
								(x, y) => (x + 1, y + 1),
							}) {
								(int observedX, int observedY) = func(x, y);
								while (observedX >= 0 && observedY >= 0 && observedX < grid[y].Count && observedY < grid.Count) {
									if (grid[observedY][observedX] != GridTile.Floor) {
										if (grid[observedY][observedX] == GridTile.OccupiedSeat) {
											++occupiedSeatsNeighbouring;
										}
										break;
									}
									(observedX, observedY) = func(observedX, observedY);

								}
							}
							if (grid[y][x] == GridTile.EmptySeat && occupiedSeatsNeighbouring == 0) {
								newGrid[y][x] = GridTile.OccupiedSeat;
								++numberOfChanges;
							} else if (grid[y][x] == GridTile.OccupiedSeat && occupiedSeatsNeighbouring >= 5) {
								newGrid[y][x] = GridTile.EmptySeat;
								++numberOfChanges;
							}
						}
					}
				}
				grid = newGrid;
			}

			return grid.Sum(r => r.Sum(c => c == GridTile.OccupiedSeat ? 1 : 0));
		}

		public static List<List<T>> Clone2DList<T>(this List<List<T>> l) {
			return new List<List<T>>(l.Select(r => new List<T>(r)));
		}
	}
}
