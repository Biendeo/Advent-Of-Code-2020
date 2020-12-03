using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day03.Part1 {
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
			int count = 0;
			for (int y = 0; y < height; ++y) {
				count += geology[(y * 3) % width, y] ? 1 : 0;
			}
			return count;
		}
	}
}
