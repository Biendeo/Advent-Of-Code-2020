using AdventOfCodeLib.Day03;
using AdventOfCodeLib.Day03.Part1;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day03 {
	public class PartOneTests {
		[Theory]
		[InlineData("..##.......,#...#...#..,.#....#..#.,..#.#...#.#,.#...##..#.,..#.##.....,.#.#.#....#,.#........#,#.##...#...,#...##....#,.#..#...#.#", 7)]
		public void TestTraverse(string input, int expectedValue) {
			string[] splitInput = input.Split(',');
			bool[,] geology = new bool[splitInput.Length, splitInput[0].Length];
			for (int y = 0; y < splitInput.Length; ++y) {
				for (int x = 0; x < splitInput[y].Length; ++x) {
					geology[y, x] = splitInput[x][y] == '#';
				}
			}
			Assert.Equal(expectedValue, Solution.Solve(geology));
		}
	}
}
