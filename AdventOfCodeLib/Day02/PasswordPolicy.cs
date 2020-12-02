using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day02 {
	public record PasswordPolicy {
		int AtLeast;
		int AtMost;
		char Letter;
		string Password;

		public PasswordPolicy(string input) {
			string[] passSplit = input.Split(':');
			Password = passSplit[1].Substring(1);
			string[] letterSplit = passSplit[0].Split(' ');
			Letter = letterSplit[1][0];
			string[] numberSplit = letterSplit[0].Split('-');
			AtLeast = int.Parse(numberSplit[0]);
			AtMost = int.Parse(numberSplit[1]);
		}

		public PasswordPolicy(int atLeast, int atMost, char letter, string password) {
			AtLeast = atLeast;
			AtMost = atMost;
			Letter = letter;
			Password = password;
		}

		public bool IsValidPartOne {
			get {
				int count = Password.Count(c => c == Letter);
				return count >= AtLeast && count <= AtMost;
			}
		}

		public bool IsValidPartTwo => (Password[AtLeast - 1] == Letter || Password[AtMost - 1] == Letter) && Password[AtLeast - 1] != Password[AtMost - 1];

		public static List<PasswordPolicy> FromInputLines(IEnumerable<string> input) {
			return input.Select(i => new PasswordPolicy(i)).ToList();
		}
	}
}
