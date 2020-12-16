using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day16 {
	public class Ticket {
		public List<int> Numbers;
		public Ticket(IEnumerable<int> numbers) {
			Numbers = new(numbers);
		}

		public int ErrorRate(List<MultiRange> rules) {
			int sum = 0;
			foreach (int num in Numbers) {
				if (!rules.Any(rule => rule.IsInRange(num))) {
					sum += num;
				}
			}
			return sum;
		}

		public bool IsError(List<MultiRange> rules) {
			return Numbers.Any(num => !rules.Any(rules => rules.IsInRange(num)));
		}
	}
}
