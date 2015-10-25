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
			Optimize("Lich King");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		private static void Optimize(string monsterName)
		{
			var monster = Library.Monsters.First(x => x.Name == monsterName);

			var simulator = new SingleMonsterSimulator(monster, 40, 40);
			var fitnessEvaluator = new PartyFitness(simulator);
			
			var population = new Population(5,
				new ShortArrayChromosome(fitnessEvaluator.ChromosomeLength, fitnessEvaluator.ChromosomeMaxValue), 
				fitnessEvaluator,
				new RankSelection());
		}
	}
}