using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day12 {
	public enum Direction {
		East,
		South,
		West,
		North
	}

	public static class DirectionExtensions {
		public static Direction Left(this Direction d) {
			switch (d) {
				case Direction.East:
				default:
					return Direction.North;
				case Direction.South:
					return Direction.East;
				case Direction.West:
					return Direction.South;
				case Direction.North:
					return Direction.West;
			}
		}

		public static Direction Right(this Direction d) {
			switch (d) {
				case Direction.East:
				default:
					return Direction.South;
				case Direction.South:
					return Direction.West;
				case Direction.West:
					return Direction.North;
				case Direction.North:
					return Direction.East;
			}
		}
	}
}
