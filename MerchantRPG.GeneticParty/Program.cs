using System;
using System.Linq;
using AForge.Genetic;
using MerchantRPG.Data;

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
			var fitnessEvaluator = new PartyFitness(Library.Monsters.First(x => x.Name == monsterName));
			var population = new Population(5, new ShortArrayChromosome(10, 40), fitnessEvaluator, new RankSelection());
		}
	}
}