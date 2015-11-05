using System;
using System.Linq;
using MerchantRPG.Simulation;

namespace MerchantRPG.ItemScore
{
	class Program
	{
		public static void Main(string[] args)
		{
			Score("Antares' Stinger", attack:4, magicAttack:53, accuracy:56, criticalRate:7, hp:24, intelligence:5);
			Score("Antares' Stinger", attack:3, magicAttack:57, accuracy:62, criticalRate:6, hp:25, intelligence:5);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

		static void Score(string itemName, double attack = 0, double magicAttack = 0, double accuracy = 0, double criticalRate = 0, double defense = 0, double magicDefense = 0, double hp = 0, double strength = 0, double intelligence = 0, double dexterity = 0)
		{
			var item = ItemFilter.MakeItems(40).First(x => x.Name == itemName);
			
			Console.WriteLine(itemName);
			WriteStatDiff("Atk ", attack, item.Attack);
			WriteStatDiff("Matk", magicAttack, item.MagicAttack);
			WriteStatDiff("Acc ", accuracy, item.Accuracy);
			WriteStatDiff("Crit", criticalRate, item.CriticalRate);
			WriteStatDiff("Def ", defense, item.Defense);
			WriteStatDiff("Mdef", magicDefense, item.MagicDefense);
			WriteStatDiff("HP  ", hp, item.HP);
			WriteStatDiff("Str ", strength, item.Strength);
			WriteStatDiff("Int ", intelligence, item.Intelligence);
			WriteStatDiff("Dex ", dexterity, item.Dexterity);
			Console.WriteLine();
		}

		static void WriteStatDiff(string statName, double itemValue, double perfectValue)
		{
			if (itemValue > 0 || perfectValue > 0)
				Console.WriteLine("{0} {1,3:##0} / {2,3:##0} {3,3:##0}", statName, itemValue, perfectValue, itemValue - perfectValue);
		}
	}
}