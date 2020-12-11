using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day11 {
	public enum GridTile {
		Floor,
		EmptySeat,
		OccupiedSeat
	}

	public static class GridTileExtensions {
		public static GridTile CharToGrid(char c) {
			switch (c) {
				case '.':
				default:
					return GridTile.Floor;
				case 'L':
					return GridTile.EmptySeat;
				case '#':
					return GridTile.OccupiedSeat;
			}
		}
	}
}
