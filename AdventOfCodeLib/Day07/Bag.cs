using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.Day07 {
	public class Bag {
		public string Color { get; init; }
		public List<BagQuantity> Contains => contains;
		private List<BagQuantity> contains;

		public Bag(string color) {
			Color = color;
			contains = new();
		}

		public bool IsOrContainsShinyGold => Color == "shiny gold" || Contains.Exists(bq => bq.Bag.IsOrContainsShinyGold);
		public int SubBagCount => Contains.Sum(bq => bq.BagQuanity * (bq.Bag.SubBagCount + 1));

		public static List<Bag> ParseBagInput(string[] input) {
			List<Bag> seenBags = new();
			foreach (string line in input) {
				if (line.Length > 0) {
					string[] splitString = line.Split(' ');
					string color = string.Join(' ', splitString[0..2]);
					Bag bag = NewOrGetExistingBag(seenBags, color);
					if (string.Join(' ', splitString[4..6]) != "no other") {
						for (int i = 4; i < splitString.Length; i += 4) {
							int quantity = int.Parse(splitString[i]);
							string subBagColor = string.Join(' ', splitString[(i + 1)..(i + 3)]);
							Bag subBag = NewOrGetExistingBag(seenBags, subBagColor);
							bag.Contains.Add(new BagQuantity {
								Bag = subBag,
								BagQuanity = quantity
							});
						}
					}
				}
			}
			return seenBags;
		}

		private static Bag NewOrGetExistingBag(List<Bag> seenBags, string color) {
			Bag bag = seenBags.FirstOrDefault(b => b.Color == color);
			if (bag == default) {
				bag = new(color);
				seenBags.Add(bag);
			}
			return bag;
		}
	}
}
