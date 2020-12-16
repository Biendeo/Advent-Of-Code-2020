using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day16 {
	public class Range {
		public int Min { get; init; }
		public int Max { get; init; }
		public Range(int min, int max) {
			Min = min;
			Max = max;
		}
		public bool IsInRange(int x) => x >= Min && x <= Max;
	}
}
