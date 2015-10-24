using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerchantRPG.Data;
using MerchantRPG.Simulation;

namespace MerchantRPG.GeneticParty
{
	abstract class ASimulator
	{
		protected Monster monster;
		protected Dictionary<Hero, Dictionary<ItemSlot, Stats[]>> AllItems;
		private int maxItemChoices = 0;

		public ASimulator(Monster monster, int heroLevel, int itemLevel)
		{
			this.monster = monster;

			foreach (var hero in Library.Heroes)
			{
				AllItems.Add(hero, ItemFilter.RelevantFor(hero, itemLevel, monster, BuildPurpose.MinTurns));
				maxItemChoices = Math.Max(maxItemChoices, AllItems[hero].Values.Max(x => x.Length));
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
	}
}
