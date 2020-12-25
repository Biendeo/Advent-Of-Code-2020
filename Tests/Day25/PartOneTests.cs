using AdventOfCodeLib.Day25.Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Day25 {
	public class PartOneTests {
		[Theory]
		[InlineData(5764801, 17807724, 14897079)]
		public void TestEncryptionkey(ulong cardPublicKey, ulong doorPublicKey, ulong expectedValue) {
			Assert.Equal(expectedValue, Solution.Solve(cardPublicKey, doorPublicKey));
		}
	}
}
