using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day17 {
	public record Grid3 {
		public int X;
		public int Y;
		public int Z;

		public List<Grid3> Neighbours {
			get {
				List<Grid3> r = new();
				for (int x = X - 1; x <= X + 1; ++x) {
					for (int y = Y - 1; y <= Y + 1; ++y) {
						for (int z = Z - 1; z <= Z + 1; ++z) {
							if (x != X || y != Y || z != Z) {
								r.Add(this with {
									X = x,
									Y = y,
									Z = z
								});
							}
						}
					}
				}
				return r;
			}
		}
	}
}
