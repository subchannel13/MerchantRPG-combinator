using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merchant_RPG_build.MetaData;

namespace Merchant_RPG_build.Processing
{
	class EquipmentBuild
	{
		public readonly int[] Combination;
		public readonly Item[] Items;
		public Stats TotalStats;
		public double Score;

		public EquipmentBuild(int[] combination)
		{
			this.Combination = combination;
			this.Items = new Item[combination.Length];
		}
	}
}

