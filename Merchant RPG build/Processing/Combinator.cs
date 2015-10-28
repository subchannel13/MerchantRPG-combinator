using System;
using System.Collections.Generic;
using System.Linq;
using MerchantRPG.Data;
using MerchantRPG.Simulation;

namespace Merchant_RPG_build.Processing
{
	public class Combinator
	{
		private const int MaxBuilds = 1;

		private Dictionary<ItemSlot, Stats[]> AllItems;
		private ItemSlot[] Slots;
		private List<EquipmentBuild> BuildCombinations;
		private static readonly List<BattleScenario> battleTurns = new List<BattleScenario>();

		public IEnumerable<EquipmentBuild> AnalyzeHero(Hero hero, int heroLevel, Monster monster, BuildPurpose buildFor, int? maxItemLevel = null)
		{
			initItems(hero, maxItemLevel ?? heroLevel, monster, buildFor);

			var heroStats = new Stats(hero, heroLevel, monster);

			for (int i = 0; i < BuildCombinations.Count; i++)
			{
				var totalStats = new Stats(heroStats);

				for (int slot = 0; slot < Slots.Length; slot++)
				{
					BuildCombinations[i].Items[slot] = AllItems[Slots[slot]][BuildCombinations[i].Combination[slot]].OriginalItem;
					totalStats += AllItems[Slots[slot]][BuildCombinations[i].Combination[slot]];
				}

				double hitRate = Math.Min(1, totalStats.Accuracy + 0.8 / (1 + 2 * monster.Evasion / 100.0));
				double criticalRate = Math.Min(totalStats.CriticalRate, 1);
				double avgBattleLength = calcBattleLength((int)Math.Ceiling(monster.HP / totalStats.Damage), criticalRate) / hitRate;

				BuildCombinations[i].TotalStats = totalStats;
				switch (buildFor)
				{
					case BuildPurpose.MaxDefense:
						BuildCombinations[i].Score = monster.Attack / (1 + totalStats.Defense) + monster.MagicAttack / (1 + totalStats.MagicDefense);
						break;
					case BuildPurpose.MaxEffectiveHp:
						BuildCombinations[i].Score = totalStats.Hp / (monster.Attack / (1 + totalStats.Defense) + monster.MagicAttack / (1 + totalStats.MagicDefense));
						break;
					case BuildPurpose.MinHpLoss:
						BuildCombinations[i].Score = (monster.Attack / (1 + totalStats.Defense) + monster.MagicAttack / (1 + totalStats.MagicDefense)) * avgBattleLength;
						break;
					case BuildPurpose.MinTurns:
						BuildCombinations[i].Score = avgBattleLength;
						break;
				}
			}

			if (buildFor == BuildPurpose.MaxEffectiveHp)
				BuildCombinations.Sort((a, b) => b.Score.CompareTo(a.Score)); //descending sort
			else
				BuildCombinations.Sort((a, b) => a.Score.CompareTo(b.Score));

			return BuildCombinations.Take(MaxBuilds).ToArray();
		}

		private void initItems(Hero hero, int maxItemLevel, Monster monster, BuildPurpose buildFor)
		{
			var statsMask = (StatsFilter)0;
			switch (buildFor)
			{
				case BuildPurpose.MaxDefense:
					statsMask = StatsFilter.Defenses;
					break;
				case BuildPurpose.MaxEffectiveHp:
					statsMask = StatsFilter.Defenses | StatsFilter.Hp;
					break;
				case BuildPurpose.MinHpLoss:
					statsMask = StatsFilter.Defenses | StatsFilter.Offensive;
					break;
				case BuildPurpose.MinTurns:
					statsMask = StatsFilter.Offensive;
					break;
			}
			
			this.AllItems = ItemFilter.RelevantFor(hero, maxItemLevel, monster, statsMask);
			this.Slots = AllItems.Keys.OrderBy(x => (int)x).ToArray();
			this.BuildCombinations = new List<EquipmentBuild>();

			BuildCombinations.Add(new EquipmentBuild(0, new int[Slots.Length]));
			bool moreCombinations = true;

			while (moreCombinations)
			{
				var build = new EquipmentBuild(BuildCombinations.Count, new int[Slots.Length]);
				for (int i = 0; i < Slots.Length; i++)
					build.Combination[i] = BuildCombinations[BuildCombinations.Count - 1].Combination[i];

				build.Combination[0]++;
				for (int i = 0; i < Slots.Length; i++)
					if (build.Combination[i] >= AllItems[Slots[i]].Length)
						if (i + 1 < Slots.Length)
						{
							build.Combination[i] = 0;
							build.Combination[i + 1]++;
						}
						else
							moreCombinations = false;

				if (moreCombinations)
					BuildCombinations.Add(build);
			}
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
