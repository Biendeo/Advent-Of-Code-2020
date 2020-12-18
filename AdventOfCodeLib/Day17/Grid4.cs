using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day17 {
	public record Grid4 {
		public int X;
		public int Y;
		public int Z;
		public int W;

		public List<Grid4> Neighbours {
			get {
				List<Grid4> r = new();
				for (int x = X - 1; x <= X + 1; ++x) {
					for (int y = Y - 1; y <= Y + 1; ++y) {
						for (int z = Z - 1; z <= Z + 1; ++z) {
							for (int w = W - 1; w <= W + 1; ++w) {
								if (x != X || y != Y || z != Z || w != W) {
									r.Add(this with
									{
										X = x,
										Y = y,
										Z = z,
										W = w
									});
								}
							}
						}
					}
				}
				return r;
			}
		}
	}
}
