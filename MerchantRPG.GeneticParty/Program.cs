﻿using System;
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
			Optimize("Serket");
			Optimize("Oni",
			         new string[] {
						"Berserker: Antares' Stinger, Undead Helm, King's Guard, Arthus' Gauntlets, Serket's Treads, Skeletor's Ring,",
						"Warrior: Antares' Stinger, Undead Helm, King's Guard, Arthus' Gauntlets, Serket's Treads, Skeletor's Ring,",
						"Paladin: Antares' Stinger, Undead Hat, King's Guard, Arthus' Gauntlets, Altor's Sandals, Skeletor's Ring,",
						"Cleric: Antares' Stinger, Undead Hat, Undead Robe, Undead Mitts, Altor's Sandals, Lizard Amulet,",
						"Mage: Antares' Stinger, Undead Hat, Undead Robe, Undead Mitts, Altor's Sandals, Skeletor's Ring,",
						"Dark Knight: Antares' Stinger, Undead Hat, Undead Robe, Arthus' Gauntlets, Altor's Sandals, Skeletor's Ring,",
					},
					3
			);
			//HardestOpponent();

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		private static void Optimize(string monsterName, string[] startingBuild = null, ushort startingBuildFrontRow = 0)
		{
			var monster = Library.Monsters.First(x => x.Name == monsterName);

			var simulator = monster.MaxPartyMembers > 1 ?
				(ASimulator)new PartySimulator(monster, 40, 40, false) :
			    (ASimulator)new SingleHeroSimulator(monster, 40, 40);
			
			
			double lastFitness = 0;
			while(true)
			{
				var fitnessEvaluator = new PartyFitness(simulator);
				var ancestor = (startingBuild == null) ?
					new ShortArrayChromosome(fitnessEvaluator.ChromosomeLength, fitnessEvaluator.ChromosomeMaxValue) :
					fitnessEvaluator.TranslateBack(simulator.TranslateBack(startingBuild), startingBuildFrontRow);
				
				var population = new Population(20,
					ancestor, 
					fitnessEvaluator,
					new RankSelection());
				population.RandomSelectionPortion = 0.15;
					
				for(int stagnation = 0; stagnation < 5000; stagnation++)
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

		private static void HardestOpponent()
		{
			var challenges = Library.Monsters.ToDictionary(x => x, x => 0.0);

			while (true)
			{
				var minScore = challenges.Values.Min();
				var monster = challenges.First(x => x.Value == minScore).Key;

				var simulator = monster.MaxPartyMembers > 1 ?
				(ASimulator)new PartySimulator(monster, 40, 40, false) :
				(ASimulator)new SingleHeroSimulator(monster, 40, 40);

				var fitnessEvaluator = new PartyFitness(simulator);
				var population = new Population(20,
					new ShortArrayChromosome(fitnessEvaluator.ChromosomeLength, fitnessEvaluator.ChromosomeMaxValue),
					fitnessEvaluator,
					new RankSelection());
				population.RandomSelectionPortion = 0.15;

				double lastFitness = 0;
				int stagnationLimit = minScore < 1e-4 ? 1000 : 10000;
				
				for (int stagnation = 0; stagnation < stagnationLimit; stagnation++)
				{
					population.RunEpoch();
					if (population.BestChromosome.Fitness > lastFitness)
					{
						lastFitness = population.BestChromosome.Fitness;
						stagnation = 0;

						if (lastFitness > challenges[monster])
						{
							challenges[monster] = lastFitness;

							Console.WriteLine(monster.Name);
							Console.Write(fitnessEvaluator.Translate(population.BestChromosome).Trim());
							Console.WriteLine(" " + population.BestChromosome.Fitness);
							Console.WriteLine();
						}
					}

					population.MutationRate = stagnation > 1000 ?
						Math.Min(stagnation / 3000.0, 0.25) :
						0.1;
				}
			}
		}
	}
}