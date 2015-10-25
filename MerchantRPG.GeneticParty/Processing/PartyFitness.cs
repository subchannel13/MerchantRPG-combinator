using System;
using AForge.Genetic;
using MerchantRPG.Data;
using System.Collections.Generic;

namespace MerchantRPG.GeneticParty.Processing
{
	class PartyFitness : IFitnessFunction
	{
		private const int BuildSize = 1 + //hero class
						(int)ItemSlot.N + //hero items
						3; //potion A type, potion B type, potion A count (potion B count is deduced)
		private const int MaxPotions = 8;
		private const int PotionTypes = 5;
		private const double InvalidChromosomeScore = 5000;

		private readonly ASimulator simulator;

		public PartyFitness(ASimulator simulator)
		{
			this.simulator = simulator;
		}

		public int ChromosomeLength
		{
			get 
			{
				return simulator.PartySize * BuildSize + 1;
			}
		}

		public int ChromosomeMaxValue
		{
			get
			{
				return Math.Max(simulator.MaxItemChoices, Math.Max(Library.Heroes.Length, PotionTypes));
			}
		}

		#region IFitnessFunction implementation

		public double Evaluate(IChromosome chromosome)
		{
			var chrom = chromosome as ShortArrayChromosome;
			double fitness = 0;
			int invalidGenes = 0;

			var builds = new List<HeroBuild>();
			for (int heroI = 0; heroI < simulator.PartySize; heroI++)
			{
				int offset = heroI * BuildSize;
				var items = new int[(int)ItemSlot.N];
				Array.Copy(chrom.Value, offset + 1, items, 0, items.Length);

				var build = new HeroBuild(
					chrom.Value[offset],
					items,
					new int[] { chrom.Value[offset + BuildSize - 3], chrom.Value[offset + BuildSize - 2] },
					new int[] { chrom.Value[offset + BuildSize - 1], MaxPotions - chrom.Value[offset + BuildSize - 1] }
				);
				builds.Add(build);

				if (build.HeroType >= Library.Heroes.Length)
					invalidGenes += build.HeroType - Library.Heroes.Length + 1;
				if (build.PotionTypes[0] >= PotionTypes)
					invalidGenes += build.PotionTypes[0] - PotionTypes + 1;
				if (build.PotionTypes[1] >= PotionTypes)
					invalidGenes += build.PotionTypes[1] - PotionTypes + 1;
				if (build.PotionCounts[0] >= MaxPotions)
					invalidGenes += build.PotionCounts[0] - MaxPotions;
				for (int i = 0; i < build.Items.Length; i++)
					if (build.Items[i] >= simulator.ItemChoices(i))
						invalidGenes += build.Items[i] - simulator.ItemChoices(i) + 1;
			}

			if (chrom.Value[simulator.PartySize * BuildSize] < 1)
				invalidGenes += 1;
			if (chrom.Value[simulator.PartySize * BuildSize] > 3)
				invalidGenes += chrom.Value[simulator.PartySize * BuildSize] - 3;

			if (invalidGenes > 0)
				return InvalidChromosomeScore + invalidGenes;

			return 0;
		}

		#endregion
	}
}
