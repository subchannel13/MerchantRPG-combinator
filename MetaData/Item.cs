using System;
using System.Linq;
using System.Reflection;

namespace Merchant_RPG_build.MetaData
{
	public class Item
	{
		public readonly string Name;
		public readonly int Level;
		public readonly ItemSlot Slot;
		
		public readonly double Attak;
		public readonly double MagicAttak;
		public readonly double Accuracy;
		public readonly double CriticalRate;
		
		public readonly double Defense;
		public readonly double MagicDefense;
		
		public readonly double Strength;
		public readonly double Intelligence;
		public readonly double Dexterity;
		public readonly double HP;

		public Item(string name, int level, ItemSlot slot, double attak = 0, double magicAttak = 0, double accuracy = 0, double criticalRate = 0, double defense = 0, double magicDefense = 0, double strength = 0, double intelligence = 0, double dexterity = 0, double hp = 0)
		{
			this.Name = name;
			this.Level = level;
			this.Slot = slot;
			this.Attak = attak;
			this.MagicAttak = magicAttak;
			this.Accuracy = accuracy;
			this.CriticalRate = criticalRate;
			this.Defense = defense;
			this.MagicDefense = magicDefense;
			this.Strength = strength;
			this.Intelligence = intelligence;
			this.Dexterity = dexterity;
			this.HP = hp;
		}

		public static FieldInfo[] StatFields = initStatFields();

		private static FieldInfo[] initStatFields()
		{
			var ignoreFields = new string[]
			{
				"StatFields", "Name", "Level", "Slot", "HP"
			};
			return typeof(Item).GetFields().Where(x => !ignoreFields.Contains(x.Name)).ToArray();
		}
	}
}
