using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merchant_RPG_build.MetaData;
using System.Reflection;

namespace Merchant_RPG_build.Processing
{
	class Stats
	{
		public Item OriginalItem;

		public double Damage;
		public double Accuracy;
		public double CriticalRate;

		public double Defense;
		public double MagicDefense;

		public Stats()
		{
			this.OriginalItem = null;

			this.Damage = 0;
			this.Accuracy = 0;
			this.CriticalRate = 0;
			this.Defense = 0;
			this.MagicDefense = 0;
		}

		public Stats(Stats original)
		{
			this.OriginalItem = original.OriginalItem;

			this.Damage = original.Damage;
			this.Accuracy = original.Accuracy;
			this.CriticalRate = original.CriticalRate;
			this.Defense = original.Defense;
			this.MagicDefense = original.MagicDefense;
		}

		public Stats(Item item, Hero forHero, Monster vsMonster)
		{
			this.OriginalItem = item;

			this.Damage =
				(item.Attack + item.Strength * forHero.Strength) / (1 + vsMonster.Defense / 100.0) +
				(item.MagicAttack + item.Intelligence * forHero.Intelligence) / (1 + vsMonster.MagicDefense / 100.0);

			this.Accuracy = (item.Accuracy + item.Dexterity * forHero.Dexterity) / 100.0;
			this.CriticalRate = item.CriticalRate / 100.0;
			this.Defense = item.Defense / 100.0;
			this.MagicDefense = item.MagicDefense / 100.0;
		}

		public Stats(Hero hero, int heroLevel, Monster vsMonster)
		{
			this.OriginalItem = null;

			this.Damage =
				(hero.StartAttack + hero.LevelAttack * heroLevel) / (1 + vsMonster.Defense / 100.0) +
				(hero.StartMagicAttack + hero.LevelMagicAttack * heroLevel) / (1 + vsMonster.MagicDefense / 100.0);

			this.Accuracy = (hero.StartAccuracy + hero.LevelAccuracy * heroLevel) / 100.0;
			this.CriticalRate = (hero.StartCriticalRate + hero.LevelCriticalRate * heroLevel) / 100.0;
			this.Defense = (hero.StartDefense + hero.LevelDefense * heroLevel) / 100.0;
			this.MagicDefense = (hero.StartMagicDefense + hero.LevelMagicDefense * heroLevel) / 100.0;
		}

		private Stats(Item originalItem, double attack, double accuracy, double criticalRate, double defense, double magicDefense)
		{
			this.Accuracy = accuracy;
			this.Damage = attack;
			this.CriticalRate = criticalRate;
			this.Defense = defense;
			this.MagicDefense = magicDefense;
			this.OriginalItem = originalItem;
		}

		public static Stats operator +(Stats left, Stats right)
		{
			return new Stats(
				null,
				left.Damage + right.Damage,
				left.Accuracy + right.Accuracy,
				left.CriticalRate + right.CriticalRate,
				left.Defense + right.Defense,
				left.MagicDefense + right.MagicDefense);
		}

		public static FieldInfo[] Fields = initStatFields();

		private static FieldInfo[] initStatFields()
		{
			var ignoreFields = new string[]
			{
				"Fields", "OriginalItem"
			};
			return typeof(Stats).GetFields().Where(x => !ignoreFields.Contains(x.Name)).ToArray();
		}
	}
}
