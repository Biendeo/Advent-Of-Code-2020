using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day19 {
	public class MultipleSequenceRule : IRule {
		private int number;
		public int Number => number;

		public List<int> Sequence1;
		public List<int> Sequence2;
		private HashSet<string> cachedEvaluation;


		public MultipleSequenceRule(int number, IEnumerable<int> sequence1, IEnumerable<int> sequence2) {
			this.number = number;
			Sequence1 = new(sequence1);
			Sequence2 = new(sequence2);
			cachedEvaluation = null;
		}

		public HashSet<string> Evaluate(IDictionary<int, IRule> rules) {
			// This prevents part 2 from super looping.
			if (Sequence2.Contains(Number)) {
				return null;
			}
			if (cachedEvaluation == null) {
				HashSet<string> current1 = rules[Sequence1.First()].Evaluate(rules);
				// Some very specific part 2 code...
				if (current1 == null) {
					return null;
				}
				for (int i = 1; i < Sequence1.Count; ++i) {
					HashSet<string> newSet = new();
					HashSet<string> evaluatedSet = rules[Sequence1[i]].Evaluate(rules);
					if (evaluatedSet == null) {
						return null;
					}
					foreach (string s in evaluatedSet) {
						foreach (string t in current1) {
							newSet.Add($"{t}{s}");
						}
					}
					current1 = newSet;
				}
				HashSet<string> current2 = rules[Sequence2.First()].Evaluate(rules);
				if (current2 == null) {
					return null;
				}
				for (int i = 1; i < Sequence2.Count; ++i) {
					HashSet<string> newSet = new();
					HashSet<string> evaluatedSet = rules[Sequence2[i]].Evaluate(rules);
					if (evaluatedSet == null) {
						return null;
					}
					foreach (string s in evaluatedSet) {
						foreach (string t in current2) {
							newSet.Add($"{t}{s}");
						}
					}
					current2 = newSet;
				}
				current2.UnionWith(current1);
				cachedEvaluation = current2;
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
					// This assumes that 8 prepends one rule, and 11 puts one rule on either side.
					if (Number == 8) {
						foreach (string p in rules[42].Evaluate(rules)) {
							if (s.StartsWith(p)) {
								if (DoesRuleMatch(rules, s[p.Length..])) {
									return true;
								}
							}
						}
						return false;
					} else if (Number == 11) {
						foreach (string p in rules[42].Evaluate(rules)) {
							foreach (string q in rules[31].Evaluate(rules)) {
								if (s.StartsWith(p) && s.EndsWith(q) && s.Length >= p.Length + q.Length) {
									if (DoesRuleMatch(rules, s[p.Length..^q.Length])) {
										return true;
									}
								}
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
