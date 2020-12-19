using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day19 {
	public class SequenceRule : IRule {
		private int number;
		public int Number => number;

		public List<int> Sequence;
		private HashSet<string> cachedEvaluation;


		public SequenceRule(int number, IEnumerable<int> sequence) {
			this.number = number;
			Sequence = new(sequence);
			cachedEvaluation = null;
		}

		public HashSet<string> Evaluate(IDictionary<int, IRule> rules) {
			if (cachedEvaluation == null) {
				HashSet<string> current = rules[Sequence.First()].Evaluate(rules);
				// Some very specific part 2 code...
				if (current == null) {
					return null;
				}
				for (int i = 1; i < Sequence.Count; ++i) {
					HashSet<string> newSet = new();
					foreach (string s in rules[Sequence[i]].Evaluate(rules)) {
						foreach (string t in current) {
							newSet.Add($"{t}{s}");
						}
					}
					current = newSet;
				}
				cachedEvaluation = current;
			}

			return cachedEvaluation;
		}
		public bool DoesRuleMatch(IDictionary<int, IRule> rules, string s) {
			if (cachedEvaluation != null) {
				return Evaluate(rules).Contains(s);
			} else {
				// Specific part 2 logic to deal with loops.
				if (s == string.Empty) {
					return true;
				} else {
					// This assumes 0 is the only sequential rule that actually contains 8 and 11.
					if (Number == 0) {
						for (int i = 1; i < s.Length; ++i) {
							if (rules[8].DoesRuleMatch(rules, s[0..i]) && rules[11].DoesRuleMatch(rules, s[i..s.Length])) {
								return true;
							}
						}
						return false;
					} else {
						// Never hit this!
						return false;
					}
				}
			}
		}
	}
}
