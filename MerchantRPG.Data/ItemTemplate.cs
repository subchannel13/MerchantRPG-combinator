using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantRPG.Data
{
	public class ItemTemplate
	{
		public readonly string Name;
		public readonly int Level;
		public readonly ItemSlot Slot;
		public readonly ItemStereotype Stereotype;

		public readonly double Attack;
		public readonly double MagicAttack;
		public readonly double Accuracy;
		public readonly double CriticalRate;

		public readonly double Defense;
		public readonly double MagicDefense;

		public readonly double Strength;
		public readonly double Intelligence;
		public readonly double Dexterity;
		public readonly double HP;

		public ItemTemplate(string name, int level, ItemSlot slot, ItemStereotype stereotype, double attack = 0, double magicAttack = 0, double accuracy = 0, double criticalRate = 0, double defense = 0, double magicDefense = 0, double strength = 0, double intelligence = 0, double dexterity = 0, double hp = 0)
		{
			this.Name = name;
			this.Level = level;
			this.Slot = slot;
			this.Stereotype = stereotype;
			this.Attack = attack;
			this.MagicAttack = magicAttack;
			this.Accuracy = accuracy;
			this.CriticalRate = criticalRate;
			this.Defense = defense;
			this.MagicDefense = magicDefense;
			this.Strength = strength;
			this.Intelligence = intelligence;
			this.Dexterity = dexterity;
			this.HP = hp;
		}

		public Item Make(double roll)
		{
			return new Item(this,
				statFunc(Stereotype.AttackBase, Stereotype.AttackPerLevel, roll) + Attack,
				statFunc(Stereotype.MagicAttackBase, Stereotype.MagicAttackPerLevel, roll) + MagicAttack,
				statFunc(Stereotype.AccuracyBase, Stereotype.AccuracyPerLevel, roll) + Accuracy,
				Stereotype.CriticalRate + CriticalRate,
				statFunc(Stereotype.DefenseBase, Stereotype.DefensePerLevel, roll) + Defense,
				statFunc(Stereotype.MagicDefenseBase, Stereotype.MagicDefensePerLevel, roll) + MagicDefense,
				Strength,
				Intelligence,
				Dexterity,
				HP);
		}

		private double statFunc(double baseValue, double perLevelValue, double roll)
		{
			return Math.Ceiling((baseValue + Level * perLevelValue) * (0.9 + 0.2 * roll));
		}
	}
}
