using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantRPG.Simulation
{
	public class BattleScenario
	{
		const int CacheSlots = 100;
		const int MaxScenarioDepth = 20;

		private CritBinome[] binomes;
		private double[] cachedTurns;

		public BattleScenario(int monsterHits)
		{
			this.cachedTurns = new double[CacheSlots + 1];

			if (monsterHits <= MaxScenarioDepth)
			{
				var subScenarios = new List<CritBinome>();
				analyzeScenario(subScenarios, monsterHits, 0, 0);
				this.binomes = subScenarios.ToArray();

				for (int i = 0; i <= CacheSlots; i++)
					this.cachedTurns[i] = binomes.Sum(x => x.Evaluate(i / (double)CacheSlots));
			}
			else
			{
				this.binomes = null;
				for (int i = 0; i <= CacheSlots; i++)
					this.cachedTurns[i] = monsterHits * (1 + i / (double)CacheSlots);
			}
		}

		public double AverageTurns(double criticalRate)
		{
			return cachedTurns[(int)Math.Round(criticalRate * CacheSlots)];
		}

		private void analyzeScenario(List<CritBinome> subScenarios, int hitsLeft, int prevCrits, int prevNonCrits)
		{
			subScenarios.Add(new CritBinome(prevCrits, prevNonCrits + 1));
			subScenarios.Add(new CritBinome(prevCrits + 1, prevNonCrits));

			if (hitsLeft > 1)
				analyzeScenario(subScenarios, hitsLeft - 1, prevCrits, prevNonCrits + 1);
			if (hitsLeft > 2)
				analyzeScenario(subScenarios, hitsLeft - 2, prevCrits + 1, prevNonCrits);
		}
	}
}
