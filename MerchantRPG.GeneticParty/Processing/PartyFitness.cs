using System;
using System.Linq;
using System.Text;
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
		private const double InvalidChromosomeScore = 10000;

		private readonly ASimulator simulator;
		private readonly Dictionary<ushort[], ChromosomeDescription> descriptions = new Dictionary<ushort[], ChromosomeDescription>();

		public PartyFitness(ASimulator simulator)
		{
			this.simulator = simulator;
		}

		public int ChromosomeLength
		{
			get 
			{
				return simulator.PartySize * BuildSize + (simulator.PartySize > 1 ? 1 : 0);
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
			double[] hpLoss;
			int invalidGenes = 0;

			var builds = new List<HeroBuild>();
			int frontRow = 1;
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
				else
					for (int i = 0; i < build.Items.Length; i++)
					{
						var maxIndex = simulator.ItemChoices(Library.Heroes[build.HeroType], i);
						if (build.Items[i] >= maxIndex)
							invalidGenes += build.Items[i] - maxIndex + 1;
					}
				
				if (build.PotionTypes[0] >= PotionTypes)
					invalidGenes += build.PotionTypes[0] - PotionTypes + 1;
				if (build.PotionTypes[1] >= PotionTypes)
					invalidGenes += build.PotionTypes[1] - PotionTypes + 1;
				if (build.PotionCounts[0] >= MaxPotions)
					invalidGenes += build.PotionCounts[0] - MaxPotions;
			}

			if (simulator.PartySize > 1)
			{
				frontRow = chrom.Value[simulator.PartySize * BuildSize];
				
				if (chrom.Value[simulator.PartySize * BuildSize] < 1)
					invalidGenes += 1;
				if (chrom.Value[simulator.PartySize * BuildSize] > 3)
					invalidGenes += chrom.Value[simulator.PartySize * BuildSize] - 3;
			}
			

			if (invalidGenes > 0)
			{
				descriptions.Add(chrom.Value, new ChromosomeDescription(null, 0, invalidGenes));
				return 1 / (InvalidChromosomeScore + invalidGenes);
			}
			
			hpLoss = simulator.Run(builds, frontRow);
			double healCost = 0;
			for (int i = 0; i < hpLoss.Length; i++)
				healCost += Math.Abs(hpLoss[i] - ASimulator.HeroDead) < 1e-2 ? 
					2 : 
					hpLoss[i];
						
			descriptions.Add(chrom.Value, new ChromosomeDescription(builds, frontRow, 0));
			return 1 / (healCost + 1);
		}

		#endregion
		
		public string Translate(IChromosome chromosome)
		{
			var chromValue = (chromosome as ShortArrayChromosome).Value;
			var description = new ChromosomeDescription(null, 0, 0);
			foreach(var desc in descriptions)
				if (chromValue.SequenceEqual(desc.Key))
				{
					description = desc.Value;
					break;
				}
			
			descriptions.Clear();
			descriptions.Add(chromValue, description);
			
			if (description.InvalidGenes > 0)
				return "Invalid genes: " + description.InvalidGenes;
			    
			var sb = new StringBuilder();
			
			for (int heroI = 0; heroI < simulator.PartySize; heroI++)
			{
				if (heroI + 1 == description.FrontRowCount && simulator.PartySize > 1)
					sb.AppendLine("Back row:");
				
				var build = description.Builds[heroI];
				var hero = Library.Heroes[build.HeroType];
				sb.Append(hero.Name + ": ");
				
				for(int i = 0; i < build.Items.Length; i++)
				{
					if (i > 0)
						sb.Append(", ");
					sb.Append(simulator.ItemData(hero, i, build.Items[i]).Name);
				}
				
				sb.Append(", ");
				sb.Append(build.PotionCounts[0]);
				sb.Append(" x ");
				sb.Append(potionName(build.PotionTypes[0]));
				
				sb.Append(", ");
				sb.Append(build.PotionCounts[1]);
				sb.Append(" x ");
				sb.Append(potionName(build.PotionTypes[1]));
				sb.AppendLine();
			}
			
			return sb.ToString();
		}
		
		private string potionName(int potionType)
		{
			if (potionType == 1)
				return "atk";
			if (potionType == 2)
				return "matk";
			if (potionType == 3)
				return "def";
			return potionType == 4 ? 
				"mdef" : 
				"acc";
		}
	}
}
