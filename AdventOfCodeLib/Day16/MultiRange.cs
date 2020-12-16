using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day16 {
	public class MultiRange {
		public string Field { get; init; }
		public Range FirstRange { get; init; }
		public Range SecondRange { get; init; }
		public MultiRange(string field, int minA, int maxA, int minB, int maxB) {
			Field = field;
			FirstRange = new(minA, maxA);
			SecondRange = new(minB, maxB);
		}
		public bool IsInRange(int x) => FirstRange.IsInRange(x) || SecondRange.IsInRange(x);
	}
}
