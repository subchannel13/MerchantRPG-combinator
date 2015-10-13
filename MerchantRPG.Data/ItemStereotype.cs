using System;

namespace MerchantRPG.Data
{
	public class ItemStereotype
	{
		public readonly double AttackBase;
		public readonly double MagicAttackBase;
		public readonly double AccuracyBase;
		public readonly double CriticalRate;

		public readonly double DefenseBase;
		public readonly double MagicDefenseBase;

		public readonly double AttackPerLevel;
		public readonly double MagicAttackPerLevel;
		public readonly double AccuracyPerLevel;

		public readonly double DefensePerLevel;
		public readonly double MagicDefensePerLevel;

		public ItemStereotype(double attackBase, double magicAttackBase, double accuracyBase, double criticalRateBase,
			double defenseBase, double magicDefenseBase, double attackPerLevel, double magicAttackPerLevel,
			double accuracyPerLevel, double defensePerLevel, double magicDefensePerLevel)
		{
			this.AccuracyBase = accuracyBase;
			this.AccuracyPerLevel = accuracyPerLevel;
			this.AttackBase = attackBase;
			this.AttackPerLevel = attackPerLevel;
			this.CriticalRate = criticalRateBase;
			this.DefenseBase = defenseBase;
			this.DefensePerLevel = defensePerLevel;
			this.MagicAttackBase = magicAttackBase;
			this.MagicAttackPerLevel = magicAttackPerLevel;
			this.MagicDefenseBase = magicDefenseBase;
			this.MagicDefensePerLevel = magicDefensePerLevel;
		}
	}
}
