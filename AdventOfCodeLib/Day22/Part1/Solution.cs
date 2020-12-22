using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day22.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			input = input.Where(s => s != string.Empty).ToArray();
			int playerTwoIndex = input.ToList().IndexOf("Player 2:");
			List<int> playerOneDeck = input[1..playerTwoIndex].Select(x => int.Parse(x)).ToList();
			List<int> playerTwoDeck = input[(playerTwoIndex + 1)..].Select(x => int.Parse(x)).ToList();

			while (playerOneDeck.Count > 0 && playerTwoDeck.Count > 0) {
				int p1Card = playerOneDeck.First();
				int p2Card = playerTwoDeck.First();
				playerOneDeck.RemoveAt(0);
				playerTwoDeck.RemoveAt(0);
				if (p1Card > p2Card) {
					playerOneDeck.Add(p1Card);
					playerOneDeck.Add(p2Card);
				} else if (p2Card > p1Card) {
					playerTwoDeck.Add(p2Card);
					playerTwoDeck.Add(p1Card);
				} else {
					//? Will this ever run?
				}
			}

			List<int> winningPlayerDeck = playerOneDeck.Count > 0 ? playerOneDeck : playerTwoDeck;

			int sum = 0;
			for (int i = 1; i <= winningPlayerDeck.Count; ++i) {
				sum += i * winningPlayerDeck[^i];
			}

			return sum;
		}
	}
}
