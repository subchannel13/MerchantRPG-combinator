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
						3; //enhancment A type, enhancment B type, enhancment A count (enhancment B count is deduced)
		
		private const int MaxEnhancment = 8;
		private const int EnhancmentTypes = 5;
		private const int BoostTypes = 5;
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
				return Math.Max(simulator.MaxItemChoices, Math.Max(Library.Heroes.Length, EnhancmentTypes));
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
				var itemCount = items.Length;
				Array.Copy(chrom.Value, offset + 1, items, 0, itemCount);

				var build = new HeroBuild(
					chrom.Value[offset],
					items,
					new int[] { chrom.Value[offset + itemCount + 1], chrom.Value[offset + itemCount + 2] },
					new int[] { chrom.Value[offset + itemCount + 3], MaxEnhancment - chrom.Value[offset + itemCount + 3] }
				);
				builds.Add(build);

				if (build.HeroType >= Library.Heroes.Length)
					invalidGenes += build.HeroType - Library.Heroes.Length + 1;
				else
					for (int i = 0; i < build.Items.Length; i++)
					{
						var maxIndex = simulator.ItemChoices(Library.Heroes[build.HeroType], i);
						if (maxIndex == 0)
							continue; //skip if there is no item for a slot
						if (build.Items[i] >= maxIndex)
							invalidGenes += build.Items[i] - maxIndex + 1;
					}
				
				if (build.EnhancmentTypes[0] >= EnhancmentTypes)
					invalidGenes += build.EnhancmentTypes[0] - EnhancmentTypes + 1;
				if (build.EnhancmentTypes[1] >= EnhancmentTypes)
					invalidGenes += build.EnhancmentTypes[1] - EnhancmentTypes + 1;
				if (build.EnhancmentCounts[0] >= MaxEnhancment)
					invalidGenes += build.EnhancmentCounts[0] - MaxEnhancment;

				/*for(int i = heroI + 1; i < simulator.PartySize; i++)
					if (build.HeroType == chrom.Value[i * BuildSize])
						invalidGenes++;*/
			}

			if (simulator.PartySize > 1)
			{
				frontRow = chrom.Value[simulator.PartySize * BuildSize];
				
				if (frontRow < 1 || frontRow < simulator.PartySize - 3)
					invalidGenes += 1;
				if (frontRow > 3)
					invalidGenes += chrom.Value[simulator.PartySize * BuildSize] - 3;
			}
			

			if (invalidGenes > 0)
			{
				descriptions.Add(chrom.Value, new ChromosomeDescription(null, 0, 0, invalidGenes));
				return 1 / (InvalidChromosomeScore + invalidGenes);
			}
			
			hpLoss = simulator.Run(builds, frontRow);
			double healCost = 0;
			for (int i = 0; i < hpLoss.Length; i++)
				healCost += Math.Abs(hpLoss[i] - ASimulator.HeroDead) < 1e-2 ? 
					2 : 
					hpLoss[i];
						
			descriptions.Add(chrom.Value, new ChromosomeDescription(builds, frontRow, hpLoss.Count(x => Math.Abs(x - ASimulator.HeroDead) < 1e-2), 0));
			return 1 / (healCost + 1);
		}

		#endregion
		
		public string Translate(IChromosome chromosome)
		{
			var chromValue = (chromosome as ShortArrayChromosome).Value;
			var description = new ChromosomeDescription(null, 0, 0, 0);
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
				if (heroI == description.FrontRowCount && simulator.PartySize > 1)
					sb.AppendLine("Back row:");
				
				var build = description.Builds[heroI];
				var hero = Library.Heroes[build.HeroType];
				sb.Append(hero.Name + ": ");
				
				for(int i = 0; i < build.Items.Length; i++)
				{
					if (i > 0)
						sb.Append(", ");
					if (simulator.ItemChoices(hero, i) == 0)
						continue;
					sb.Append(simulator.ItemData(hero, i, build.Items[i]).Name);
				}
				
				sb.Append(", ");
				sb.Append(build.EnhancmentCounts[0]);
				sb.Append(" x ");
				sb.Append(potionName(build.EnhancmentTypes[0]));
				
				sb.Append(", ");
				sb.Append(build.EnhancmentCounts[1]);
				sb.Append(" x ");
				sb.Append(potionName(build.EnhancmentTypes[1]));
				sb.AppendLine();
			}
			
			sb.Append(description.Deaths + " deaths");
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
