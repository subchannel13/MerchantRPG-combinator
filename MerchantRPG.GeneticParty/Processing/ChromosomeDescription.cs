using System;
using System.Collections.Generic;

namespace MerchantRPG.GeneticParty.Processing
{
	struct ChromosomeDescription
	{
		public IList<HeroBuild> Builds;
		public int FrontRowCount;
		public int InvalidGenes;
		
		public ChromosomeDescription(IList<HeroBuild> builds, int frontRowCount, int invalidGenes)
		{
			this.Builds = builds;
			this.FrontRowCount = frontRowCount;
			this.InvalidGenes = invalidGenes;
		}
	}
}
