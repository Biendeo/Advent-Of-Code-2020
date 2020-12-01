﻿using System;
using System.Diagnostics;
using System.IO;

static void RunSolution<T>(string solutionName, Func<T> solution) {
	Console.WriteLine(solutionName);
	var stopwatch = new Stopwatch();
	stopwatch.Start();
	var result = solution();
	stopwatch.Stop();
	Console.WriteLine(result);
	Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds}ms");
	Console.WriteLine();
}

RunSolution("Day 01 - Part 1", () => AdventOfCodeLib.Day01.Part1.Solution.SolveFromInputFile(Path.Combine("input", "01.txt")));
RunSolution("Day 01 - Part 2", () => AdventOfCodeLib.Day01.Part2.Solution.SolveFromInputFile(Path.Combine("input", "01.txt")));
