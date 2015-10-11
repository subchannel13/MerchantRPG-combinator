using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merchant_RPG_build.MetaData
{
	class ItemStereotype
	{
		public readonly double AttackBase;
		public readonly double MagicAttackBase;
		public readonly double AccuracyBase;
		public readonly double CriticalRateBase;

		public readonly double DefenseBase;
		public readonly double MagicDefenseBase;

		public readonly double AttackPerLevel;
		public readonly double MagicAttackPerLevel;
		public readonly double AccuracyPerLevel;
		public readonly double CriticalRatePerLevel;

		public readonly double DefensePerLevel;
		public readonly double MagicDefensePerLevel;

		public ItemStereotype(double attackBase, double magicAttackBase, double accuracyBase, double criticalRateBase,
			double defenseBase, double magicDefenseBase, double attackPerLevel, double magicAttackPerLevel,
			double accuracyPerLevel, double criticalRatePerLevel, double defensePerLevel, double magicDefensePerLevel)
		{
			this.AccuracyBase = accuracyBase;
			this.AccuracyPerLevel = accuracyPerLevel;
			this.AttackBase = attackBase;
			this.AttackPerLevel = attackPerLevel;
			this.CriticalRateBase = criticalRateBase;
			this.CriticalRatePerLevel = criticalRatePerLevel;
			this.DefenseBase = defenseBase;
			this.DefensePerLevel = defensePerLevel;
			this.MagicAttackBase = magicAttackBase;
			this.MagicAttackPerLevel = magicAttackPerLevel;
			this.MagicDefenseBase = magicDefenseBase;
			this.MagicDefensePerLevel = magicDefensePerLevel;
		}
	}
}
