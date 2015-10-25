using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantRPG.GeneticParty.Processing
{
	class HeroBuild
	{
		public readonly int HeroType;
		public readonly int[] Items;
		public readonly int[] PotionTypes;
		public readonly int[] PotionCounts;

		public HeroBuild(int heroType, int[] items, int[] potionTypes, int[] potionCounts)
		{
			this.HeroType = heroType;
			this.Items = items;
			this.PotionCounts = potionCounts;
			this.PotionTypes = potionTypes;
		}
	}
}
