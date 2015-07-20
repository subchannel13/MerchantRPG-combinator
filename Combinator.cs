using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merchant_RPG_build.MetaData;

namespace Merchant_RPG_build
{
	class Combinator
	{
		private const double HeroLevel = 40;
		private const double MaxEvasion = 90;
		private const int MaxBuilds = 10;

		private Dictionary<ItemSlot, Item[]> AllItems;
		private ItemSlot[] Slots;
		private List<int[]> Combinations;

		public void MakeCombinations()
		{
			this.AllItems = Library.Armorsmith.
				Concat(Library.Blacksmith).
				Concat(Library.Clothworker).
				Concat(Library.Trinkets).
				Concat(Library.Woodworker).
				GroupBy(x => x.Slot).ToDictionary(x => x.Key, x => x.ToArray());
			this.Slots = AllItems.Keys.ToArray();
			this.Combinations = new List<int[]>();

			Combinations.Add(new int[Slots.Length]);
			bool moreCombinations = true;

			while (moreCombinations)
			{
				var combination = new int[Slots.Length];
				for (int i = 0; i < Slots.Length; i++)
					combination[i] = Combinations[Combinations.Count - 1][i];

				combination[0]++;
				for (int i = 0; i < Slots.Length; i++)
					if (combination[i] >= AllItems[Slots[i]].Length)
						if (i + 1 < Slots.Length)
						{
							combination[i] = 0;
							combination[i + 1]++;
						}
						else
							moreCombinations = false;

				if (moreCombinations)
					Combinations.Add(combination);
			}
		}

		public void AnalyzeHero(Hero hero)
		{
			var buildScore = new Dictionary<int, double>();

			for (int i = 0; i < Combinations.Count; i++)
			{
				double attak = hero.StartAttak + HeroLevel * hero.LevelAttak;
				double magicAttak = hero.StartMagicAttak + HeroLevel * hero.LevelMagicAttak;
				double accuracy = hero.StartAccuracy + HeroLevel * hero.LevelAccuracy;
				double criticalRate = hero.StartCriticalRate + HeroLevel * hero.LevelCriticalRate;

				double defense = hero.StartDefense + HeroLevel * hero.LevelDefense;
				double magicDefense = hero.StartMagicDefense + HeroLevel * hero.LevelMagicDefense;

				double strength = 0;
				double intelligence = 0;
				double dexterity = 0;

				for (int slot = 0; slot < Slots.Length; slot++)
				{
					var item = AllItems[Slots[slot]][Combinations[i][slot]];

					attak += item.Attak;
					magicAttak += item.MagicAttak;
					accuracy += item.Accuracy;
					criticalRate += item.CriticalRate;

					defense += item.Defense;
					magicDefense += item.MagicDefense;

					strength += item.Strength;
					intelligence += item.Intelligence;
					dexterity += item.Dexterity;
				}

				accuracy += dexterity * hero.Dexterity;
				double hitRate = Math.Min(1, accuracy / 100.0 + 0.8 / (1 + 2 * MaxEvasion));
				criticalRate = Math.Min(criticalRate / 100.0, 1);

				double normalDamage = attak + strength * hero.Strength;
				double magicDamage = magicAttak + intelligence * hero.Intelligence;
				buildScore.Add(i, (normalDamage + magicDamage) * hitRate * (1 + criticalRate));
			}

			var buildRanks = new List<int>(buildScore.Keys);
			buildRanks.Sort((a, b) => buildScore[b].CompareTo(buildScore[a]));

			Console.WriteLine(hero.Name + ":");
			for (int i = 0; i < MaxBuilds && i < buildRanks.Count; i++)
			{
				var build = Combinations[buildRanks[i]];
				for (int slot = 0; slot < Slots.Length; slot++)
					Console.Write(AllItems[Slots[slot]][build[slot]].Name + ", ");
				Console.WriteLine("score: " + buildScore[buildRanks[i]]);
			}

			Console.WriteLine();
		}
	}
}
