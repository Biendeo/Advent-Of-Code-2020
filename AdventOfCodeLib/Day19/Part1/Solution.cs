using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day19.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			int gapIndex = input.ToList().IndexOf(string.Empty);
			Dictionary<int, IRule> rules = new();
			for (int i = 0; i < gapIndex; ++i) {
				int ruleNumber = int.Parse(input[i].Split(':')[0]);
				string remainingRule = input[i].Split(':')[1].Trim();
				if (remainingRule.Contains('"')) {
					rules.Add(ruleNumber, new LetterRule(ruleNumber, remainingRule[1]));
				} else if (remainingRule.Contains('|')) {
					IEnumerable<int> sequence1 = remainingRule.Split('|')[0].Trim().Split(' ').Select(x => int.Parse(x));
					IEnumerable<int> sequence2 = remainingRule.Split('|')[1].Trim().Split(' ').Select(x => int.Parse(x));
					rules.Add(ruleNumber, new MultipleSequenceRule(ruleNumber, sequence1, sequence2));
				} else {
					IEnumerable<int> sequence = remainingRule.Split(' ').Select(x => int.Parse(x));
					rules.Add(ruleNumber, new SequenceRule(ruleNumber, sequence));
				}
			}

			HashSet<string> thingsToMatch = rules[0].Evaluate(rules);
			return input[(gapIndex + 1)..].Count(s => thingsToMatch.Contains(s));
		}
	}
}
