using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day08.Part2 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			input = input.Where(s => s.Length > 0).ToArray();
			int flipIndex = 0;
			int acc = 0;
			bool foundSolution = false;
			while (!foundSolution && flipIndex < input.Length) {
				HashSet<int> runProgramCounters = new();
				int pc = 0;
				acc = 0;
				while (pc < input.Length && !runProgramCounters.Contains(pc)) {
					runProgramCounters.Add(pc);
					string command = input[pc][0..3];
					if (command == "acc") {
						acc += int.Parse(input[pc][4..]);
						++pc;
					} else if (command == "nop" && flipIndex == pc || command == "jmp" && flipIndex != pc) {
						pc += int.Parse(input[pc][4..]);
					} else if (command == "jmp" && flipIndex == pc || command == "nop" && flipIndex != pc) {
						++pc;
					}
				}
				if (pc >= input.Length) {
					foundSolution = true;
				} else {
					++flipIndex;
					acc = -1;
				}
			}
			return acc;
		}
	}
}
