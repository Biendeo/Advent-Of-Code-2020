using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day21.Part1 {
	public static class Solution {
		public static int SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static int Solve(string[] input) {
			input = input.Where(s => s != string.Empty).ToArray();

			List<(List<string> Ingredients, List<string> ListedAllergens)> inputRecipes = new();
			foreach (string s in input) {
				inputRecipes.Add((s.Split('(')[0][0..^1].Split(' ').ToList(), s.Split('(')[1][8..^1].Split(',').Select(x => x.Trim()).ToList()));
			}

			Dictionary<string, int> ingredientFrequencies = new();
			Dictionary<string, int> allergenFrequencies = new();
			foreach (var recipe in inputRecipes) {
				foreach (var ingredient in recipe.Ingredients) {
					ingredientFrequencies[ingredient] = ingredientFrequencies.ContainsKey(ingredient) ? ingredientFrequencies[ingredient] + 1 : 1;
				}
				foreach (var allergen in recipe.ListedAllergens) {
					allergenFrequencies[allergen] = allergenFrequencies.ContainsKey(allergen) ? allergenFrequencies[allergen] + 1 : 1;
				}
			}
			List<string> allIngredients = new(ingredientFrequencies.Keys);
			List<string> allAllergens = new(allergenFrequencies.Keys);

			bool[,] allergensToIngredients = new bool[allIngredients.Count, allAllergens.Count];

			FindPermutation(allIngredients, allAllergens, allergensToIngredients, inputRecipes, 0);

			int frequencySum = 0;
			for (int x = 0; x < allIngredients.Count; ++x) {
				if (Enumerable.Range(0, allAllergens.Count).All(y => !allergensToIngredients[x, y])) {
					frequencySum += ingredientFrequencies[allIngredients[x]];
				}
			}

			return frequencySum;
		}

		internal static bool FindPermutation(List<string> allIngredients, List<string> allAllergens, bool[,] allergensToIngredients, List<(List<string> Ingredients, List<string> ListedAllergens)> inputRecipes, int i) {
			if (i >= allAllergens.Count) {
				return true;
			}
			string currentAllergen = allAllergens[i];
			for (int x = 0; x < allIngredients.Count; ++x) {
				bool allergenAlreadyLocked = false;
				for (int y = 0; y < i; ++y) {
					allergenAlreadyLocked |= allergensToIngredients[x, y];
				}
				if (!allergenAlreadyLocked) {
					allergensToIngredients[x, i] = true;

					string currentIngredient = allIngredients[x];
					if (inputRecipes.All(recipe => !recipe.ListedAllergens.Contains(currentAllergen) || recipe.ListedAllergens.Contains(currentAllergen) && recipe.Ingredients.Contains(currentIngredient)) && FindPermutation(allIngredients, allAllergens, allergensToIngredients, inputRecipes, i + 1)) {
						return true;
					}

					allergensToIngredients[x, i] = false;
				}
			}
			return false;
		}
	}
}
