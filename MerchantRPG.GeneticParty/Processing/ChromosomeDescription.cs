using System;
using System.Collections.Generic;

namespace MerchantRPG.GeneticParty.Processing
{
	struct ChromosomeDescription
	{
		public IList<HeroBuild> Builds;
		public int FrontRowCount;
		public int InvalidGenes;
		public int Deaths;
		
		public ChromosomeDescription(IList<HeroBuild> builds, int frontRowCount, int deaths, int invalidGenes)
		{
			this.Builds = builds;
			this.FrontRowCount = frontRowCount;
			this.InvalidGenes = invalidGenes;
			this.Deaths = deaths;
		}
	}
}
