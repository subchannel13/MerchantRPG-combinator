using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerchantRPG.Data;

namespace MerchantRPG.GeneticParty.Processing
{
	class SingleMonsterSimulator : ASimulator
	{
		public SingleMonsterSimulator(Monster monster, int heroLevel, int itemLevel) : base(monster, heroLevel, itemLevel)
		{ }

		public override object Run()
		{
			throw new NotImplementedException();
		}
	}
}
