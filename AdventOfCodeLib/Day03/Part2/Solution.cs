using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day03.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) {
			string[] inputRead = File.ReadAllLines(inputFile);
			bool[,] geology = new bool[inputRead[0].Length, inputRead.Length];
			for (int y = 0; y < inputRead.Length; ++y) {
				for (int x = 0; x < inputRead[y].Length; ++x) {
					geology[x, y] = inputRead[y][x] == '#';
				}
			}
			return Solve(geology);
		}

		public static int Solve(bool[,] geology) {
			int width = geology.GetLength(0);
			int height = geology.GetLength(1);
			var increments = new (int X, int Y)[] {
				(1, 1),
				(3, 1),
				(5, 1),
				(7, 1),
				(1, 2)
			};
			int product = 1;
			foreach (var increment in increments) {
				int count = 0;
				for (int y = 0, x = 0; y < height; y += increment.Y, x += increment.X) {
					count += geology[x % width, y] ? 1 : 0;
				}
				product *= count;
			}
			return product;
		}
	}
}
