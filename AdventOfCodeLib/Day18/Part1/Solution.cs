using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day18.Part1 {
	public static class Solution {
		public static long SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static long Solve(string[] input) {
			return input.Sum(s => Equate(s));
		}

		public static long Equate(string equation) {
			Stack<int> bracketIndex = new();

			List<long> numbers = new();
			List<bool> operatorPlus = new();

			string[] splitString = equation.Split(' ');
			int bracketDepth = 0;
			int bracketStart = 0;
			for (int i = 0; i < splitString.Length; ++i) {
				if (splitString[i].Contains('(')) {
					if (bracketDepth == 0) {
						bracketStart = i;
					}
					bracketDepth += splitString[i].Where(c => c == '(').Count();
				} 
				if (bracketDepth == 0) {
					if (splitString[i] == "+") {
						operatorPlus.Add(true);
					} else if (splitString[i] == "*") {
						operatorPlus.Add(false);
					} else {
						numbers.Add(long.Parse(splitString[i]));
					}
				}
				if (splitString[i].Contains(')')) {
					bracketDepth -= splitString[i].Where(c => c == ')').Count();
					if (bracketDepth == 0) {
						string subEquation = string.Join(' ', splitString[bracketStart..(i + 1)]);
						numbers.Add(Equate(subEquation[1..^1]));
					}
				}
			}

			long result = numbers.First();
			for (int i = 0; i < operatorPlus.Count; ++i) {
				if (operatorPlus[i]) {
					result += numbers[i + 1];
				} else {
					result *= numbers[i + 1];
				}
			}

			return result;
		}
	}
}
