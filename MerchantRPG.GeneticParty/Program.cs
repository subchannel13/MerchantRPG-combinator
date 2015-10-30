using System;
using System.Linq;
using AForge.Genetic;
using MerchantRPG.Data;
using MerchantRPG.GeneticParty.Processing;

namespace MerchantRPG.GeneticParty
{
	class Program
	{
		public static void Main(string[] args)
		{
			Optimize("Oni");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		private static void Optimize(string monsterName)
		{
			var monster = Library.Monsters.First(x => x.Name == monsterName);

			var simulator = monster.MaxPartyMembers > 1 ?
				(ASimulator)new PartySimulator(monster, 40, 40, false) :
			    (ASimulator)new SingleHeroSimulator(monster, 40, 40);
			
			
			double lastFitness = 0;
			while(true)
			{
				var fitnessEvaluator = new PartyFitness(simulator);
				var population = new Population(20,
					new ShortArrayChromosome(fitnessEvaluator.ChromosomeLength, fitnessEvaluator.ChromosomeMaxValue), 
					fitnessEvaluator,
					new RankSelection());
				population.RandomSelectionPortion = 0.15;
					
				for(int stagnation = 0; stagnation < 10000; stagnation++)
				{
					population.RunEpoch();
					if (population.BestChromosome.Fitness > lastFitness)
					{
						lastFitness = population.BestChromosome.Fitness;
						Console.Write(fitnessEvaluator.Translate(population.BestChromosome).Trim());
						Console.WriteLine(" " + population.BestChromosome.Fitness);
						Console.WriteLine();
						stagnation = 0;
					}
					
					population.MutationRate = stagnation > 1000 ? 
						Math.Min(stagnation / 3000.0, 0.25) : 
						0.1;
				}
			}
		}
	}
}