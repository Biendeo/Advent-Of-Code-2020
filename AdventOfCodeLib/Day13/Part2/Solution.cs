using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day13.Part2 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static long Solve(string[] input) {
			string[] splitInput = input[1].Split(',');
			List<(int ID, int Offset)> buses = new();
			for (int i = 0; i < splitInput.Length; ++i) {
				if (splitInput[i] != "x") {
					buses.Add((int.Parse(splitInput[i]), i));
				}
			}

			long lcm = 1;
			long t = 0;
			foreach (var bus in buses) {
				while ((t + bus.Offset) % bus.ID != 0) {
					t += lcm;
				}
				lcm = LCM(lcm, bus.ID);
			}

			return t;
		}

		private static long GCF(long a, long b) {
			while (b != 0) {
				long temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}

		private static long LCM(long a, long b) =>  (a / GCF(a, b)) * b;
	}
}
