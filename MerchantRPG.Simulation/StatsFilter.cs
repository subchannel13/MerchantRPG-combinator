using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantRPG.Simulation
{
	[Flags()]
	public enum StatsFilter
	{
		Damage = 1 << 0,	//Any damage type
		Accuracy = 1 << 1,
		CriticalRate = 1 << 2,

		Defense = 1 << 3,
		MagicDefense = 1 << 4,
		Hp = 1 << 5,

		Offensive = Damage | Accuracy | CriticalRate,
		Defenses = Defense | MagicDefense,
		All = Offensive | Defenses | Hp,
		
		MagicAttack = 1 << 6,
	}
}
