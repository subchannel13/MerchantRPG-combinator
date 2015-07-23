using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merchant_RPG_build.MetaData
{
	public class Monster
	{
		public readonly string Name;
		public readonly int Level;
		public readonly int MaxPartyMembers;
		
		public readonly double Attack;
		public readonly double MagicAttack;
		public readonly double Evasion;
		
		public readonly double Defense;
		public readonly double MagicDefense;
		public readonly double HP;

		public Monster(string name, int level, double attack, double magicAttack, double evasion, double defense, double magicDefense, double hp, int maxPartyMembers = 1)
		{
			this.Name = name;
			this.Level = level;
			this.MaxPartyMembers = maxPartyMembers;
			this.Attack = attack;
			this.MagicAttack = magicAttack;
			this.Evasion = evasion;
			this.Defense = defense;
			this.MagicDefense = magicDefense;
			this.HP = hp;
		}
	}
}