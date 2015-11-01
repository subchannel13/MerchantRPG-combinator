using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerchantRPG.Data;

namespace MerchantRPG.Simulation
{
	public static class ItemFilter
	{
		public static IEnumerable<Item> MakeItems(int maxItemLevel)
		{
			return Library.Armorsmith.
				Concat(Library.Blacksmith).
				Concat(Library.Clothworker).
				Concat(Library.Woodworker).Select(x => x.Make(1)).
				Concat(Library.Boosts).
				Concat(Library.Trinkets).Where(x => x.Level <= maxItemLevel);
		}

		public static Dictionary<ItemSlot, Stats[]> RelevantFor(Hero hero, int maxItemLevel, Monster monster, StatsFilter statsMask)
		{
			return removeRedundantItems(
				MakeItems(maxItemLevel),
				hero, monster, statsMask);
		}

		private static Dictionary<ItemSlot, Stats[]> removeRedundantItems(IEnumerable<Item> items, Hero hero, Monster monster, StatsFilter statsMask)
		{
			var itemGroups = items.Select(x => new Stats(x, hero, monster)).GroupBy(x => x.OriginalItem.Slot);
			var filteredItems = new Dictionary<ItemSlot, Stats[]>();

			foreach (var itemGroup in itemGroups)
			{
				var filteredList = new List<Stats>();
				foreach (var item in itemGroup)
				{
					bool redundant = false;
					var superiorTo = new HashSet<Stats>();
					foreach (var filteredItem in filteredList)
					{
						if (item.isSuperiorTo(filteredItem, statsMask))
							superiorTo.Add(filteredItem);
						redundant |= item.isInferiorTo(filteredItem, statsMask);
					}
					foreach (var toRemove in superiorTo)
						filteredList.Remove(toRemove);
					if (!redundant)
						filteredList.Add(item);
				}

				if (filteredList.Count == 0)
				{
					var maxDamage = itemGroup.Max(x => x.Damage);
					filteredList.Add(itemGroup.First(x => Math.Abs(x.Damage - maxDamage) < 1e-3));
				}

				filteredItems.Add(itemGroup.Key, filteredList.ToArray());
			}

			return filteredItems;
		}
	}
}
