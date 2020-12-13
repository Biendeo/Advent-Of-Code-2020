using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day13.Part1 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static long Solve(string[] input) {
			int earliestTime = int.Parse(input[0]);
			List<int> busIds = input[1].Split(',').Where(x => x != "x").Select(x => int.Parse(x)).ToList();
			int numberOfMinutesWaited = -1;
			int foundBusId = -1;
			bool foundBus = false;
			while (!foundBus) {
				++numberOfMinutesWaited;
				for (int i = 0; i < busIds.Count && !foundBus; ++i) {
					foundBusId = busIds[i];
					if ((earliestTime + numberOfMinutesWaited) % foundBusId == 0) {
						foundBus = true;
					}
				}
			}
			return foundBusId * numberOfMinutesWaited;
		}
	}
}
