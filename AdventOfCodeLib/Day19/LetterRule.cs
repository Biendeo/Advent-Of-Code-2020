using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day19 {
	public class LetterRule : IRule {
		private int number;
		public int Number => number;
		public char Letter { get; init; }

		public LetterRule(int number, char letter) {
			this.number = number;
			Letter = letter;
		}

		public HashSet<string> Evaluate(IDictionary<int, IRule> _) => new HashSet<string>(new[] { $"{Letter}" });
		public bool DoesRuleMatch(IDictionary<int, IRule> rules, string s) => Evaluate(rules).Contains(s);
	}
}
