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
		protected Monster monster;
		protected Dictionary<Hero, Stats[][]> AllItems = new Dictionary<Hero, Stats[][]>();
		private int maxItemChoices = 0;
		private int[] itemChoices;

		public ASimulator(Monster monster, int heroLevel, int itemLevel)
		{
			this.monster = monster;
			this.itemChoices = new int[(int)ItemSlot.N];

			foreach (var hero in Library.Heroes)
			{
				var relevantItems = ItemFilter.RelevantFor(hero, itemLevel, monster, BuildPurpose.MinTurns);
				var items = new Stats[(int)ItemSlot.N][];
				for (int i = 0; i < relevantItems.Count; i++)
				{
					items[i] = relevantItems[(ItemSlot)i];
					itemChoices[i] = Math.Max(itemChoices[i], items[i].Length);
				}

				AllItems.Add(hero, items);
				maxItemChoices = Math.Max(maxItemChoices, itemChoices.Max());
			}
		}

		public abstract object Run();

		public int MaxItemChoices
		{
			get { return maxItemChoices; }
		}

		public int PartySize
		{
			get { return monster.MaxPartyMembers; }
		}

		public int ItemChoices(int slot)
		{
			return itemChoices[slot];
		}
	}
}
