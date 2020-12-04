using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day04 {
	public record Passport {
		public string BirthYear { get; init; }
		public string IssueYear { get; init; }
		public string ExpirationYear { get; init; }
		public string Height { get; init; }
		public string HairColor { get; init; }
		public string EyeColor { get; init; }
		public string PassportID { get; init; }
		public string CountryId { get; init; }

		public bool IsValidPartOne => BirthYear != null && IssueYear != null && ExpirationYear != null && Height != null && HairColor != null && EyeColor != null && PassportID != null;

		public bool IsValidPartTwo {
			get {
				if (!IsValidPartOne) return false;
				if (!int.TryParse(BirthYear, out int birthYear)) return false;
				if (birthYear < 1920 || birthYear > 2002) return false;
				if (!int.TryParse(IssueYear, out int issueYear)) return false;
				if (issueYear < 2010 || issueYear > 2020) return false;
				if (!int.TryParse(ExpirationYear, out int expirationYear)) return false;
				if (expirationYear < 2020 || expirationYear > 2030) return false;
				if (Height.Length < 2) return false;
				string heightUnit = Height[^2..];
				if (heightUnit != "cm" && heightUnit != "in") return false;
				if (!int.TryParse(Height[..^2], out int height)) return false;
				if (heightUnit == "cm" && (height < 150 || height > 193)) return false;
				if (heightUnit == "in" && (height < 59 || height > 76)) return false;
				if (HairColor.Length != 7 && !Regex.IsMatch(HairColor, "#[0-9a-f]{6}")) return false;
				if (!new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(EyeColor)) return false;
				if (!Regex.IsMatch(PassportID, "^[0-9]{9}$")) return false;
				return true;
			}
		}

		public static int Solve(string input, Func<Passport, bool> validityCheck) {
			Passport currentPassport = new Passport();
			int totalValidPassports = 0;
			List<Passport> passports = new();

			string[] splitInput = input.Split(new[] { Environment.NewLine, " " }, StringSplitOptions.None);

			foreach (string s in splitInput) {
				if (s.Length == 0) {
					totalValidPassports += validityCheck(currentPassport) ? 1 : 0;
					passports.Add(currentPassport);
					currentPassport = new Passport();
				} else {
					string[] keyPair = s.Split(':');
					switch (keyPair[0]) {
						case "byr": currentPassport = currentPassport with { BirthYear = keyPair[1] }; break;
						case "iyr": currentPassport = currentPassport with { IssueYear = keyPair[1] }; break;
						case "eyr": currentPassport = currentPassport with { ExpirationYear = keyPair[1] }; break;
						case "hgt": currentPassport = currentPassport with { Height = keyPair[1] }; break;
						case "hcl": currentPassport = currentPassport with { HairColor = keyPair[1] }; break;
						case "ecl": currentPassport = currentPassport with { EyeColor = keyPair[1] }; break;
						case "pid": currentPassport = currentPassport with { PassportID = keyPair[1] }; break;
						case "cid": currentPassport = currentPassport with { CountryId = keyPair[1] }; break;
					}
				}
			}
			totalValidPassports += validityCheck(currentPassport) ? 1 : 0;
			return totalValidPassports;
		}
	}
}
