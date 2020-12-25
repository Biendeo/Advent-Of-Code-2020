using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCodeLib.Day25.Part1 {
	public static class Solution {
		public static ulong SolveFromInputFile(string inputFile) => Solve(ulong.Parse(File.ReadAllLines(inputFile)[0]), ulong.Parse(File.ReadAllLines(inputFile)[1]));
		public static ulong Solve(ulong cardPublicKey, ulong doorPublicKey) {
			ulong cardLoopSize = DetermineLoopSize(cardPublicKey, 7);
			ulong doorLoopSize = DetermineLoopSize(doorPublicKey, 7);
			return ProduceEncryptionKey(cardPublicKey, doorLoopSize);
		}

		public static ulong DetermineLoopSize(ulong publicKey, ulong subjectNumber) {
			ulong currentValue = 1;
			ulong loopSize = 0;
			while (currentValue != publicKey) {
				++loopSize;
				currentValue *= subjectNumber;
				currentValue %= 20201227;
			}
			return loopSize;
		}

		public static ulong ProduceEncryptionKey(ulong subjectNumber, ulong loopSize) {
			ulong currentValue = 1;
			for (ulong i = 0; i < loopSize; ++i) {
				currentValue *= subjectNumber;
				currentValue %= 20201227;
			}
			return currentValue;
		}
	}
}
