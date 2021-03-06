﻿using System;
using System.Linq;
using MerchantRPG.Data;

namespace MerchantRPG.Simulation
{
	public class Stats
	{
		public Item OriginalItem;

		public double Damage;
		public double Accuracy;
		public double CriticalRate;

		public double Defense;
		public double MagicDefense;
		public double Hp;

		public Stats()
		{
			this.OriginalItem = null;

			this.Damage = 0;
			this.Accuracy = 0;
			this.CriticalRate = 0;
			this.Defense = 0;
			this.MagicDefense = 0;
			this.Hp = 0;
		}

		public Stats(Stats original)
		{
			this.OriginalItem = original.OriginalItem;

			this.Damage = original.Damage;
			this.Accuracy = original.Accuracy;
			this.CriticalRate = original.CriticalRate;
			this.Defense = original.Defense;
			this.MagicDefense = original.MagicDefense;
			this.Hp = original.Hp;
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
			this.Hp = item.HP;
		}

		public Stats(Hero hero, int heroLevel, Monster vsMonster)
		{
			this.OriginalItem = null;
			heroLevel--; //Heros start at level 1 and gain per level stats afterwards

			this.Damage =
				(hero.StartAttack + hero.LevelAttack * heroLevel) / (1 + vsMonster.Defense / 100.0) +
				(hero.StartMagicAttack + hero.LevelMagicAttack * heroLevel) / (1 + vsMonster.MagicDefense / 100.0);

			this.Accuracy = (hero.StartAccuracy + hero.LevelAccuracy * heroLevel) / 100.0;
			this.CriticalRate = (hero.StartCriticalRate + hero.LevelCriticalRate * heroLevel) / 100.0;
			this.Defense = (hero.StartDefense + hero.LevelDefense * heroLevel) / 100.0;
			this.MagicDefense = (hero.StartMagicDefense + hero.LevelMagicDefense * heroLevel) / 100.0;
			this.Hp = hero.StartHP + hero.LevelHP * heroLevel;
		}
		
		public Stats(StatsFilter bonusType, Monster vsMonster)
		{
			this.OriginalItem = null;

			this.Damage = 0;
			this.Accuracy = 0;
			this.CriticalRate = 0;
			this.Defense = 0;
			this.MagicDefense = 0;
			this.Hp = 0;
			
			if (bonusType == StatsFilter.Damage)
				this.Damage = 1 / (1 + vsMonster.Defense / 100.0);
			if (bonusType == StatsFilter.MagicAttack)
				this.Damage = 1 / (1 + vsMonster.MagicDefense / 100.0);
			
			if (bonusType == StatsFilter.Accuracy)
				this.Accuracy = 0.01;
			if (bonusType == StatsFilter.CriticalRate)
				this.CriticalRate = 0.01;
			if (bonusType == StatsFilter.Defense)
				this.Defense = 0.01;
			if (bonusType == StatsFilter.MagicDefense)
				this.MagicDefense = 0.01;
			if (bonusType == StatsFilter.Hp)
				this.Hp = 1;
		}

		private Stats(Item originalItem, double attack, double accuracy, double criticalRate, double defense, double magicDefense, double hp)
		{
			this.Accuracy = accuracy;
			this.Damage = attack;
			this.CriticalRate = criticalRate;
			this.Defense = defense;
			this.MagicDefense = magicDefense;
			this.OriginalItem = originalItem;
			this.Hp = hp;
		}

		public bool isInferiorTo(Stats other, StatsFilter statsMask)
		{
			return (this.Damage <= other.Damage || !statsMask.HasFlag(StatsFilter.Damage)) &&
				(this.Accuracy <= other.Accuracy || !statsMask.HasFlag(StatsFilter.Accuracy)) &&
				(this.CriticalRate <= other.CriticalRate || !statsMask.HasFlag(StatsFilter.CriticalRate)) &&
				(this.Defense <= other.Defense || !statsMask.HasFlag(StatsFilter.Defense)) &&
				(this.MagicDefense <= other.MagicDefense || !statsMask.HasFlag(StatsFilter.MagicDefense)) &&
				(this.Hp <= other.Hp || !statsMask.HasFlag(StatsFilter.Hp));
		}

		public bool isSuperiorTo(Stats other, StatsFilter statsMask)
		{
			return (this.Damage >= other.Damage || !statsMask.HasFlag(StatsFilter.Damage)) &&
				(this.Accuracy >= other.Accuracy || !statsMask.HasFlag(StatsFilter.Accuracy)) &&
				(this.CriticalRate >= other.CriticalRate || !statsMask.HasFlag(StatsFilter.CriticalRate)) &&
				(this.Defense >= other.Defense || !statsMask.HasFlag(StatsFilter.Defense)) &&
				(this.MagicDefense >= other.MagicDefense || !statsMask.HasFlag(StatsFilter.MagicDefense)) &&
				(this.Hp >= other.Hp || !statsMask.HasFlag(StatsFilter.Hp));
		}

		public static Stats operator +(Stats left, Stats right)
		{
			return new Stats(
				null,
				left.Damage + right.Damage,
				left.Accuracy + right.Accuracy,
				left.CriticalRate + right.CriticalRate,
				left.Defense + right.Defense,
				left.MagicDefense + right.MagicDefense,
				left.Hp + right.Hp);
		}
		
		public static Stats operator *(Stats left, double right)
		{
			return new Stats(
				left.OriginalItem,
				left.Damage * right,
				left.Accuracy * right,
				left.CriticalRate * right,
				left.Defense * right,
				left.MagicDefense * right,
				left.Hp * right);
		}
	}
}
