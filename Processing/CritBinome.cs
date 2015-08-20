using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merchant_RPG_build.Processing
{
	class CritBinome
	{
		private readonly int criticalPower;
		private readonly int normalPower;

		public CritBinome(int criticalPower, int normalPower)
		{
			this.criticalPower = criticalPower;
			this.normalPower = normalPower;
		}

		public double Evaluate(double criticalRate)
		{
			return Math.Pow(criticalRate, criticalPower) * Math.Pow(1 - criticalRate, normalPower);
		}

		public override string ToString()
		{
			return "(c: " + criticalPower + ", n: " + normalPower + ")";
		}
	}
}
