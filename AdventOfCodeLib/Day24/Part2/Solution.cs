using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCodeLib.Day24.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			HashSet<(int X, int Y)> flippedTiles = Part1.Solution.DetermineFlippedTiles(input);

			for (int day = 0; day < 100; ++day) {
				HashSet<(int X, int Y)> newTiles = new();

				foreach (var currentTile in flippedTiles) {
					int currentTileBlackNeighbours = 0;
					foreach (var neighbour in Neighbours(currentTile.X, currentTile.Y)) {
						if (flippedTiles.Contains(neighbour)) {
							++currentTileBlackNeighbours;
						} else {
							int neighbourBlackNeighbours = 0;
							foreach (var neighboursNeighbour in Neighbours(neighbour.X, neighbour.Y)) {
								if (flippedTiles.Contains(neighboursNeighbour)) {
									++neighbourBlackNeighbours;
								}
							}
							if (neighbourBlackNeighbours == 2) {
								newTiles.Add(neighbour);
							}
						}
					}
					if (currentTileBlackNeighbours == 1 || currentTileBlackNeighbours == 2) {
						newTiles.Add(currentTile);
					}
				}

				flippedTiles = newTiles;
			}

			return flippedTiles.Count;
		}

		public static List<(int X, int Y)> Neighbours(int x, int y) {
			return new() {
				Direction.East.Move(x, y, 1),
				Direction.SouthEast.Move(x, y, 1),
				Direction.SouthWest.Move(x, y, 1),
				Direction.West.Move(x, y, 1),
				Direction.NorthWest.Move(x, y, 1),
				Direction.NorthEast.Move(x, y, 1)
			};
		}
	}
}
