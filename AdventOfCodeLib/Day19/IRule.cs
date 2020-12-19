using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day19 {
	public interface IRule {
		public int Number { get; }
		public HashSet<string> Evaluate(IDictionary<int, IRule> rules);
		public bool DoesRuleMatch(IDictionary<int, IRule> rules, string s);
	}
}
