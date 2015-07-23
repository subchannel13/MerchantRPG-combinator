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
		
		public readonly double Attak;
		public readonly double MagicAttak;
		public readonly double Evasion;
		
		public readonly double Defense;
		public readonly double MagicDefense;
		public readonly double HP;

		public Monster(string name, int level, double attak, double magicAttak, double evasion, double defense, double magicDefense, double hp, int maxPartyMembers = 1)
		{
			this.Name = name;
			this.Level = level;
			this.MaxPartyMembers = maxPartyMembers;
			this.Attak = attak;
			this.MagicAttak = magicAttak;
			this.Evasion = evasion;
			this.Defense = defense;
			this.MagicDefense = magicDefense;
			this.HP = hp;
		}
	}
}