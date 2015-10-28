using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerchantRPG.Data;
using MerchantRPG.Simulation;

namespace MerchantRPG.GeneticParty.Processing
{
	abstract class ASimulator
	{
		public const double HeroDead = 1;
		
		protected Monster monster;
		public int HeroLevel { get; private set; }
		protected Dictionary<Hero, Stats[][]> AllItems = new Dictionary<Hero, Stats[][]>();
		private int maxItemChoices = 0;

		protected ASimulator(Monster monster, int heroLevel, int itemLevel)
		{
			this.HeroLevel = heroLevel;
			this.monster = monster;

			foreach (var hero in Library.Heroes)
			{
				var relevantItems = ItemFilter.RelevantFor(hero, itemLevel, monster, BuildPurpose.MinTurns);
				var items = new Stats[(int)ItemSlot.N][];
				for (int i = 0; i < relevantItems.Count; i++)
				{
					items[i] = relevantItems[(ItemSlot)i];
					maxItemChoices = Math.Max(maxItemChoices, items[i].Length);
				}

				AllItems.Add(hero, items);
			}
		}

		public abstract double[] Run(IList<HeroBuild> builds, int frontCount);

		public int MaxItemChoices
		{
			get { return maxItemChoices; }
		}

		public int PartySize
		{
			get { return monster.MaxPartyMembers; }
		}

		public int ItemChoices(Hero hero, int slot)
		{
			return AllItems[hero][slot].Length;
		}

		public Item ItemData(Hero hero, int slot, int index)
		{
			return AllItems[hero][slot][index].OriginalItem;
		}
		
		protected Stats PotionBonus(int potionType)
		{
			var type = StatsFilter.Accuracy;
			
			if (potionType == 1)
				type = StatsFilter.Damage;
			if (potionType == 2)
				type = StatsFilter.MagicAttack;
			if (potionType == 3)
				type = StatsFilter.Defense;
			if (potionType == 4)
				type = StatsFilter.MagicDefense;
			
			return new Stats(type, monster);
		}
	}
}
