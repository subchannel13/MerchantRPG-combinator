using System;
using AForge.Genetic;
using MerchantRPG.Data;

namespace MerchantRPG.GeneticParty
{
	public class PartyFitness : IFitnessFunction
	{
		private readonly Monster monster;
		
		public PartyFitness(Monster monster)
		{
			this.monster = monster;
		}

		#region IFitnessFunction implementation

		public double Evaluate(IChromosome chromosome)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
