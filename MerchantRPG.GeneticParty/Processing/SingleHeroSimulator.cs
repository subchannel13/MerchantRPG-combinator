using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerchantRPG.Data;
using MerchantRPG.Simulation;

namespace MerchantRPG.GeneticParty.Processing
{
	class SingleHeroSimulator : ASimulator
	{
		public SingleHeroSimulator(Monster monster, int heroLevel, int itemLevel) : base(monster, heroLevel, itemLevel)
		{ }

		public override double[] Run(IList<HeroBuild> builds, int frontCount)
		{
			var heroStats = this.HeroStats(builds[0]);
			
			double avgBattleLength = calcBattleLength((int)Math.Ceiling(monster.HP / heroStats.Damage), heroStats.CriticalRate) / heroStats.Accuracy;
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
