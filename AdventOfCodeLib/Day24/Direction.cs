using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day24 {
	public enum Direction {
		East,
		SouthEast,
		SouthWest,
		West,
		NorthWest,
		NorthEast
	}

	public static class DirectionExtensions {
		public static Direction Left(this Direction d) {
			switch (d) {
				case Direction.East:
				default:
					return Direction.SouthEast;
				case Direction.SouthEast:
					return Direction.SouthWest;
				case Direction.SouthWest:
					return Direction.West;
				case Direction.West:
					return Direction.NorthWest;
				case Direction.NorthWest:
					return Direction.NorthEast;
				case Direction.NorthEast:
					return Direction.East;
			}
		}

		public static Direction Right(this Direction d) {
			switch (d) {
				case Direction.East:
				default:
					return Direction.NorthEast;
				case Direction.SouthEast:
					return Direction.East;
				case Direction.SouthWest:
					return Direction.SouthEast;
				case Direction.West:
					return Direction.SouthWest;
				case Direction.NorthWest:
					return Direction.West;
				case Direction.NorthEast:
					return Direction.NorthWest;
			}
		}

		public static (int, int) Move(this Direction d, int x, int y, int magnitude) {
			switch (d) {
				case Direction.East:
				default:
					return (x + magnitude, y);
				case Direction.SouthEast:
					return (x + magnitude, y - magnitude);
				case Direction.SouthWest:
					return (x, y - magnitude);
				case Direction.West:
					return (x - magnitude, y);
				case Direction.NorthWest:
					return (x - magnitude, y + magnitude);
				case Direction.NorthEast:
					return (x, y + magnitude);
			}
		}
	}
}
