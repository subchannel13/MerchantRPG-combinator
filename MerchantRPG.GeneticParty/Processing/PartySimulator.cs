using System;
using System.Collections.Generic;
using System.Linq;
using MerchantRPG.Data;
using MerchantRPG.Simulation;

namespace MerchantRPG.GeneticParty.Processing
{
	class PartySimulator : ASimulator
	{
		private bool exhaustive;
		
		public PartySimulator(Monster monster, int heroLevel, int itemLevel, bool exhaustiveSimulation) : base(monster, heroLevel, itemLevel)
		{
			this.exhaustive	= exhaustiveSimulation;
		}

		#region implemented abstract members of ASimulator

		public override double[] Run(IList<HeroBuild> builds, int frontCount)
		{
			var partyStats = new Stats[builds.Count];
			var partyHpLoss = new double[builds.Count];
			var totalHpLoss = new double[builds.Count];
			for(int i = 0; i < builds.Count; i++)
				partyStats[i] = this.HeroStats(builds[i]);
			
			if (exhaustive)
				takeTurn(
					totalHpLoss,
					partyStats,
					partyHpLoss,
					monster.HP,
					frontCount,
					frontCount,
					0,
					1
				);
			else
				totalHpLoss = simpleSimulation(partyStats, frontCount);
			
			return totalHpLoss;
		}

		#endregion

		private double[] simpleSimulation(Stats[] partyStats, int frontRowSeparator)
		{
			var partyHpLoss = new double[partyStats.Length];
			double monsterHp = monster.HP;
			
			while(partyHpLoss.Any(x => x < 1) && monsterHp > 0)
			{
				frontRowSeparator = partyHpLoss.Take(frontRowSeparator).Any(x => x < 1) ? frontRowSeparator : partyStats.Length;
				int frontRowCount = partyHpLoss.Take(frontRowSeparator).Count(x => x < 1);
				
				for(int i = 0; i < partyStats.Length; i++)
				{
					if (partyHpLoss[i] >= 1)
						continue;
					
					double critRate = 1 - Math.Pow(1 - partyStats[i].CriticalRate, 1);
					monsterHp -= partyStats[i].Damage * (1 + critRate) * partyStats[i].Accuracy / 2;
					
					if (i < frontRowSeparator)
						partyHpLoss[i] += (
							monster.Attack / (1 + partyStats[i].Defense) + 
							monster.MagicAttack / (1 + partyStats[i].MagicDefense)
						) / (2 * frontRowCount * partyStats[i].Hp);
					
					if (partyHpLoss[i] > 1)
						partyHpLoss[i] = 1;
				}
			}
			
			var totalHp = new double[partyStats.Length + 1];
			Array.Copy(partyHpLoss, totalHp, partyStats.Length);
			totalHp[partyStats.Length] = (monsterHp < 0) ? 0 : (monsterHp /  monster.HP);
				
			return totalHp;
		}

		private void takeTurn(double[] totalHpLoss, Stats[] partyStats, double[] partyHpLoss, double monsterHp, int frontRowSeparator, int frontRowCount, int currentHero, double stateChance)
		{	
			if (partyHpLoss.All(x => x >= 1))
			{
				addHpLoss(totalHpLoss, partyHpLoss, stateChance);
				return;
			}
			
			while(currentHero < partyStats.Length && partyHpLoss[currentHero] >= 1)
				currentHero++;
			
			if (currentHero >= partyStats.Length)
			{
				frontRowSeparator = partyHpLoss.Take(frontRowSeparator).Any(x => x < 1) ? frontRowSeparator : partyStats.Length;
				frontRowCount = partyHpLoss.Take(frontRowSeparator).Count(x => x < 1);
				currentHero = 0;
			}
			
			while(partyHpLoss[currentHero] >= 1)
				currentHero++;
			
			if (partyStats[currentHero].Accuracy < 1)
			{
				takeTurn(totalHpLoss, partyStats, 
				         monsterTurn(partyStats, partyHpLoss, frontRowCount, currentHero), 
				         monsterHp, frontRowSeparator, frontRowCount, currentHero + 1,
				         stateChance * (1 - partyStats[currentHero].Accuracy));
			}
			
			stateChance *= partyStats[currentHero].Accuracy;
			
			if (partyStats[currentHero].CriticalRate > 0)
			{
				if (monsterHp > partyStats[currentHero].Damage * 2)
					takeTurn(totalHpLoss, partyStats, 
					         monsterTurn(partyStats, partyHpLoss, frontRowCount, currentHero), 
					         monsterHp - partyStats[currentHero].Damage * 2, 
					         frontRowSeparator, frontRowCount, currentHero + 1,
					         stateChance * partyStats[currentHero].CriticalRate);
				else
					addHpLoss(totalHpLoss, partyHpLoss, stateChance * partyStats[currentHero].CriticalRate);
			}
			
			if (partyStats[currentHero].CriticalRate < 1)
			{
				if (monsterHp > partyStats[currentHero].Damage)
					takeTurn(totalHpLoss, partyStats, 
					         monsterTurn(partyStats, partyHpLoss, frontRowCount, currentHero), 
					         monsterHp - partyStats[currentHero].Damage, 
					         frontRowSeparator, frontRowCount, currentHero + 1,
					         stateChance * (1 - partyStats[currentHero].CriticalRate));
				else
					addHpLoss(totalHpLoss, partyHpLoss, stateChance * (1 - partyStats[currentHero].CriticalRate));
			}
		}
		
		private double[] monsterTurn(IList<Stats> partyStats, Array partyHpLoss, int frontRowCount, int currentHero)
		{
			var nextHpLoss = new double[partyHpLoss.Length];
			Array.Copy(partyHpLoss, nextHpLoss, partyHpLoss.Length);
			
			if (currentHero >= frontRowCount)
				return nextHpLoss;
			
			nextHpLoss[currentHero] += (
						monster.Attack / (1 + partyStats[currentHero].Defense) + 
						monster.MagicAttack / (1 + partyStats[currentHero].MagicDefense)
					) / (2 * frontRowCount * partyStats[currentHero].Hp);
			
			if (nextHpLoss[currentHero] > 1)
					nextHpLoss[currentHero] = 1;
			
			return nextHpLoss;
		}
		
		private static void addHpLoss(IList<double> destination, double[] source, double factor)
		{
			for(int i = 0; i < source.Length; i++)
				destination[i] += source[i] * factor;
		}
	}
}
