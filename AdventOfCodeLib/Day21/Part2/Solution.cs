using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeLib.Day21.Part2 {
	public static class Solution {
		public static string SolveFromInputFile(string inputFile) => Solve(File.ReadAllLines(inputFile));
		public static string Solve(string[] input) {
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

			Part1.Solution.FindPermutation(allIngredients, allAllergens, allergensToIngredients, inputRecipes, 0);

			List<(string Ingredient, string Allergen)> allergenPairs = new();
			for (int x = 0; x < allIngredients.Count; ++x) {
				for (int y = 0; y < allAllergens.Count; ++y) {
					if (allergensToIngredients[x, y]) {
						allergenPairs.Add((allIngredients[x], allAllergens[y]));
					}
				}
			}
			return string.Join(',', allergenPairs.OrderBy(p => p.Allergen).Select(p => p.Ingredient));
		}
	}
}
