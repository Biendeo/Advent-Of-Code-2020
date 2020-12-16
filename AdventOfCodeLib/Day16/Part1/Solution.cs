using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day16.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			(List<MultiRange> rules, _, List<Ticket> nearbyTickets) = ParseInput(input);
			return nearbyTickets.Sum(t => t.ErrorRate(rules));
		}

		public static (List<MultiRange> rules, Ticket yourTicket, List<Ticket> nearbyTickets) ParseInput(string[] input) {
			List<MultiRange> rules = new();
			foreach (var line in input) {
				if (line == string.Empty) {
					break;
				} else {
					int[] splitLine = line.Split(' ').Where(x => x.Contains('-')).SelectMany(x => x.Split('-')).Select(x => int.Parse(x)).ToArray();
					rules.Add(new(line.Split(':')[0], splitLine[0], splitLine[1], splitLine[2], splitLine[3]));
				}
			}

			Ticket yourTicket = new(input[input.ToList().IndexOf("your ticket:") + 1].Split(',').Select(x => int.Parse(x)));
			List<Ticket> nearbyTickets = new();
			for (int i = input.ToList().IndexOf("nearby tickets:") + 1; i < input.Length; ++i) {
				if (input[i] != string.Empty) {
					nearbyTickets.Add(new(input[i].Split(',').Select(x => int.Parse(x))));
				}
			}
			return (rules, yourTicket, nearbyTickets);
		}
	}
}
