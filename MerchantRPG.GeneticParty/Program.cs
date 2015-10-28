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
			Optimize("Haunted Harwood");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		private static void Optimize(string monsterName)
		{
			var monster = Library.Monsters.First(x => x.Name == monsterName);

			var simulator = new SingleMonsterSimulator(monster, 40, 40);
			var fitnessEvaluator = new PartyFitness(simulator);
			
			var population = new Population(20,
				new ShortArrayChromosome(fitnessEvaluator.ChromosomeLength, fitnessEvaluator.ChromosomeMaxValue), 
				fitnessEvaluator,
				new EliteSelection());
			population.RandomSelectionPortion = 0.3;
				
			double lastFitness = 0;
			for(int stagnation = 0; stagnation < 10000; stagnation++)
			{
				population.RunEpoch();
				if (population.BestChromosome.Fitness > lastFitness)
				{
					lastFitness = population.BestChromosome.Fitness;
					Console.WriteLine(fitnessEvaluator.Translate(population.BestChromosome).Trim());
					Console.WriteLine(population.BestChromosome.Fitness);
					Console.WriteLine();
					stagnation = 0;
				}
				
				if (stagnation > 1000)
					population.MutationRate = Math.Min(stagnation / 3000.0, 0.25);
				else
					population.MutationRate = 0.1;
			}
		}
	}
}