using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerchantRPG.Data;
using MerchantRPG.Simulation;

namespace MerchantRPG.GeneticParty.Processing
{
	class SingleMonsterSimulator : ASimulator
	{
		public SingleMonsterSimulator(Monster monster, int heroLevel, int itemLevel) : base(monster, heroLevel, itemLevel)
		{ }

		public override double[] Run(IList<HeroBuild> builds, int frontCount)
		{
			var build = builds[0];
			var hero = Library.Heroes[build.HeroType];
			double potionStrength = Math.Max(10, HeroLevel) / 10.0;
			
			var heroStats = new Stats(hero, HeroLevel, monster);
			heroStats += PotionBonus(build.PotionTypes[0]) * potionStrength * build.PotionCounts[0];
			heroStats += PotionBonus(build.PotionTypes[1]) * potionStrength * build.PotionCounts[1];
			
			for(int i = 0; i < build.Items.Length; i++)
				heroStats += AllItems[hero][i][build.Items[i]];
			
			double hitRate = Math.Min(1, heroStats.Accuracy + 0.8 / (1 + 2 * monster.Evasion / 100.0));
			double criticalRate = Math.Min(heroStats.CriticalRate, 1);
			double avgBattleLength = calcBattleLength((int)Math.Ceiling(monster.HP / heroStats.Damage), criticalRate) / hitRate;
			double damageTaken = (monster.Attack / (1 + heroStats.Defense) + monster.MagicAttack / (1 + heroStats.MagicDefense)) * avgBattleLength;
				
			return new double[] { damageTaken > heroStats.Hp ? HeroDead : (damageTaken / heroStats.Hp) };
		}
		
		private double calcBattleLength(int monsterHits, double criticalRate)
		{
			if (monsterHits == 1)
				return 1;
			
			int cacheRow = monsterHits - 2;
			if (cacheRow < BattleTurnsCache.Turns.Length)
				return BattleTurnsCache.Turns[cacheRow, (int)Math.Round(criticalRate)];
			
			return monsterHits / (1 + criticalRate);
		}
	}
}
