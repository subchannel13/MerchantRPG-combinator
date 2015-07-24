using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merchant_RPG_build.MetaData;
using Merchant_RPG_build.Processing;

namespace Merchant_RPG_build
{
	class Combinator
	{
		private const int MaxBuilds = 1;

		private Dictionary<ItemSlot, Stats[]> AllItems;
		private ItemSlot[] Slots;
		private List<int[]> Combinations;
		private static List<BattleScenario> battleTurns = new List<BattleScenario>();

		public void AnalyzeHero(Hero hero, int heroLevel, Monster monster)
		{
			calcBattleLength(20, 0);

			initItems(hero, heroLevel, monster);
			var buildScore = new Dictionary<int, double>();

			var heroStats = new Stats(hero, heroLevel, monster);

			for (int i = 0; i < Combinations.Count; i++)
			{
				var totalStats = new Stats(heroStats);

				for (int slot = 0; slot < Slots.Length; slot++)
					totalStats += AllItems[Slots[slot]][Combinations[i][slot]];

				double hitRate = Math.Min(1, totalStats.Accuracy + 0.8 / (1 + 2 * monster.Evasion));
				double criticalRate = Math.Min(totalStats.CriticalRate, 1);
				double avgBattleLength = calcBattleLength((int)Math.Ceiling(monster.HP / totalStats.Damage), criticalRate) / hitRate;

				//buildScore.Add(i, totalStats.Damage * hitRate * (1 + criticalRate));
				buildScore.Add(i,
					(monster.Attack / (1 + totalStats.Defense) + monster.MagicAttack / (1 + totalStats.MagicDefense)) * avgBattleLength
				);
			}

			var buildRanks = new List<int>(buildScore.Keys);
			//buildRanks.Sort((a, b) => buildScore[b].CompareTo(buildScore[a]));
			buildRanks.Sort((a, b) => buildScore[a].CompareTo(buildScore[b]));

			Console.WriteLine(hero.Name + ":");
			for (int i = 0; i < MaxBuilds && i < buildRanks.Count; i++)
			{
				var build = Combinations[buildRanks[i]];
				for (int slot = 0; slot < Slots.Length; slot++) {
					var item = AllItems[Slots[slot]][build[slot]].OriginalItem;
					Console.Write(item.Name + ", ");
				}
				Console.WriteLine("score: " + buildScore[buildRanks[i]].ToString("0.0"));
			}

			Console.WriteLine();
		}

		private void initItems(Hero hero, int maxItemLevel, Monster monster)
		{
			this.AllItems = removeRedundantItems(
				Library.Armorsmith.
				Concat(Library.Blacksmith).
				Concat(Library.Clothworker).
				Concat(Library.Trinkets).
				Concat(Library.Woodworker).Where(x => x.Level <= maxItemLevel),
				hero, monster);
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

		private Dictionary<ItemSlot, Stats[]> removeRedundantItems(IEnumerable<Item> items, Hero hero, Monster monster)
		{
			var itemGroups = items.Select(x => new Stats(x, hero, monster)).GroupBy(x => x.OriginalItem.Slot);
			var filteredItems = new Dictionary<ItemSlot, Stats[]>();

			foreach (var itemGroup in itemGroups)
			{
				var filteredList = new List<Stats>();
				foreach (var item in itemGroup)
				{
					bool redundant = false;
					var superiorTo = new HashSet<Stats>();
					foreach (var filteredItem in filteredList)
					{
						if (Stats.Fields.All(x => (double)x.GetValue(item) >= (double)x.GetValue(filteredItem)))
							superiorTo.Add(filteredItem);
						redundant |= Stats.Fields.All(x => (double)x.GetValue(item) <= (double)x.GetValue(filteredItem));
					}
					foreach (var toRemove in superiorTo)
						filteredList.Remove(toRemove);
					if (!redundant)
						filteredList.Add(item);
				}

				filteredItems.Add(itemGroup.Key, filteredList.ToArray());
			}

			return filteredItems;
		}

		private double calcBattleLength(int monsterHits, double criticalRate)
		{
			while (battleTurns.Count <= monsterHits)
			{
				if (battleTurns.Count == 0)
				{
					battleTurns.Add(null);
					continue;
				}

				battleTurns.Add(new BattleScenario(battleTurns.Count));
			}

			return battleTurns[monsterHits].AverageTurns(criticalRate);
		}

	}
}
