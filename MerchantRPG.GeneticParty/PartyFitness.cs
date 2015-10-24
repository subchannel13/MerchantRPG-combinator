using System;
using AForge.Genetic;
using MerchantRPG.Data;

namespace MerchantRPG.GeneticParty
{
	class PartyFitness : IFitnessFunction
	{
		private readonly ASimulator simulator;

		public PartyFitness(ASimulator simulator)
		{
			this.simulator = simulator;
		}

		public int ChromosomeLength
		{
			get 
			{
				return
					simulator.PartySize * (
						1 + //hero class
						(int)ItemSlot.N + //hero items
						3 //potion A type, potion B type, potion A count (potion B count is deduced)
					);
			}
		}

		public int ChromosomeMaxValue
		{
			get
			{
				return Math.Max(simulator.MaxItemChoices, Math.Max(Library.Heroes.Length, 5));
			}
		}

		#region IFitnessFunction implementation

		public double Evaluate(IChromosome chromosome)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
