using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day08.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			HashSet<int> runProgramCounters = new();
			int pc = 0;
			int acc = 0;
			while (!runProgramCounters.Contains(pc)) {
				runProgramCounters.Add(pc);
				switch (input[pc][0..3]) {
					case "acc":
						acc += int.Parse(input[pc][4..]);
						++pc;
						break;
					case "jmp":
						pc += int.Parse(input[pc][4..]);
						break;
					case "nop":
						++pc;
						break;
				}
			}
			return acc;
		}
	}
}
