using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day16.Part2 {
	public static class Solution {
		public static ulong SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static ulong Solve(string[] input) {
			(List<MultiRange> rules, Ticket yourTicket, List<Ticket> nearbyTickets) = Part1.Solution.ParseInput(input);
			List<Ticket> filteredTickets = nearbyTickets.Where(t => !t.IsError(rules)).ToList();
			filteredTickets.Add(yourTicket);
			bool[,] whichRulesWorkInWhichIndex = new bool[rules.Count, rules.Count];
			for (int i = 0; i < rules.Count; ++i) {
				for (int j = 0; j < rules.Count; ++j) {
					whichRulesWorkInWhichIndex[i, j] = filteredTickets.All(t => rules[i].IsInRange(t.Numbers[j]));
				}
			}
			MultiRange[] orderedRules = new MultiRange[rules.Count];
			while (orderedRules.Any(rule => rule == null)) {
				for (int i = 0; i < rules.Count; ++i) {
					if (!orderedRules.Contains(rules[i])) {
						for (int j = 0; j < rules.Count; ++j) {
							if (orderedRules[j] == null && whichRulesWorkInWhichIndex[i, j] && !Enumerable.Range(0, rules.Count).Where(k => k != j).Any(k => whichRulesWorkInWhichIndex[i, k] && orderedRules[k] == null)) {
								orderedRules[j] = rules[i];
							}
						}
					}
				}
			}
			ulong product = 1;
			for (int i = 0; i < rules.Count; ++i) {
				if (orderedRules[i].Field.StartsWith("departure")) {
					product *= (ulong)yourTicket.Numbers[i];
				}
			}
			return product;
		}
	}
}
