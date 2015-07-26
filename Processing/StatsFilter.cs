using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merchant_RPG_build.Processing
{
	enum StatsFilter
	{
		Damage = 1 << 0,
		Accuracy = 1 << 1,
		CriticalRate = 1 << 2,

		Defense = 1 << 3,
		MagicDefense = 1 << 4,
		Hp = 1 << 5,

		Offensive = Damage | Accuracy | CriticalRate,
		Defenses = Defense | MagicDefense,
	}
}
