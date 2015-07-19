using System;
using System.ComponentModel;

namespace Merchant_RPG_build.MetaData
{
	public static class Library
	{
		public static Hero[] Heroes = new Hero[] {
			new Hero("Warrior", 5, 1, 4,
			         100, 5, 1, 2, 1, 14, 8,
			         10, 0.4, 0.1, 0.3, 0, 1, 0.4),
			new Hero("Rogue", 4, 1, 5,
			         90, 5, 1, 2, 5, 9, 8,
			         8, 0.6, 0.1, 0.5, 0.2, 0.5, 0.4),
			new Hero("Mage", 1, 6, 3,
			         80, 1, 5, 2, 1, 7, 10,
			         7, 0.1, 0.9, 0.3, 0, 0.4, 0.4),
			new Hero("Berserker", 6, 1, 3,
			         90, 5, 1, 2, 1, 10, 7,
			         8, 0.8, 0.1, 0.3, 0, 0.5, 0.4),
			new Hero("Cleric", 1, 5, 4,
			         80, 1, 5, 2, 1, 7, 10,
			         7, 0.1, 0.6, 0.6, 0, 0.4, 0.4),
			new Hero("Assassin", 3, 1, 6,
			         90, 5, 1, 2, 10, 9, 8,
			         8, 0.4, 0.1, 0.7, 0.2, 0.5, 0.4),
			new Hero("Paladin", 4, 4, 2,
			         100, 3, 3, 2, 1, 8, 14,
			         10, 0.3, 0.3, 0.3, 0, 0.4, 1),
			new Hero("Dark Knight", 5, 5, 0,
			         80, 3, 3, 2, 1, 9, 8,
			         7, 0.5, 0.5, 0.3, 0, 0.4, 0.4)
		};
		
		public static Item[] Blacksmith = new Item[] {
			new Item("Beast Hatchet", ItemSlot.Weapon, attak: 71, magicAttak: 3, accuracy: 26, criticalRate: 2, hp: 25, dexterity: 3),
			new Item("Beast Sword", ItemSlot.Weapon, attak: 55, magicAttak: 3, accuracy: 55, criticalRate: 2, hp: 25, dexterity: 3),
			new Item("Battlelord's Blade", ItemSlot.Weapon, attak: 58 + 7, magicAttak: 5, accuracy: 58 + 7, criticalRate: 2, strength: 5),
			new Item("Overlord's Battleaxe", ItemSlot.Weapon, attak: 75, magicAttak: 5, accuracy: 22, strength: 4, criticalRate: 2 + 7),
			new Item("Ceros' Knife", ItemSlot.Weapon, attak: 50 + 5, magicAttak: 5, accuracy: 61, strength: 4, criticalRate: 10, defense: 7),
		};
		
		public static Item[] Armorsmith = new Item[] {
			new Item("Scorpion Platemail", ItemSlot.Chest, defense: 73, magicDefense: 11, magicAttak: 9, strength: 4),
			new Item("Scorpion Great Helm", ItemSlot.Helm, defense: 44, magicDefense: 7, magicAttak: 7, strength: 3),
			new Item("Scorpion Sabatons", ItemSlot.Boots, defense: 24, magicDefense: 4, magicAttak: 5, strength: 2),
			new Item("Scorpion Gauntlets", ItemSlot.Gloves, defense: 24, magicDefense: 4, magicAttak: 5, strength: 2),
			new Item("Ares' Helm", ItemSlot.Helm, defense: 36 + 5, magicDefense: 17, attak: 5, strength: 4),
			new Item("Ares' Bracers", ItemSlot.Gloves, defense: 22 + 7, magicDefense: 9, strength: 2),
			new Item("Gnoll Chainmail", ItemSlot.Chest, defense: 58, magicDefense: 19, strength: 3, criticalRate: 4),
			new Item("Fighter's Greaves", ItemSlot.Boots, defense: 22, magicDefense: 9, strength: 2, dexterity: 2),
			new Item("Gnoll Platemail", ItemSlot.Chest, defense: 64, magicDefense: 10, attak: 5, dexterity: 3),
		};
		
		public static Item[] Woodworker = new Item[] {
			new Item("Scorpion Cudgel", ItemSlot.Weapon, attak: 46 + 7, magicAttak: 46, accuracy: 17, criticalRate: 2, intelligence: 3),
			new Item("Scorpion Wand", ItemSlot.Weapon, attak: 5 + 7, magicAttak: 58, accuracy: 51, criticalRate: 2, intelligence: 3),
			new Item("Deadwood Mystic Stave", ItemSlot.Weapon, attak: 5, magicAttak: 75, accuracy: 16, criticalRate: 2),
			new Item("Ares' Stave", ItemSlot.Weapon, attak: 5, magicAttak: 75, accuracy: 28, criticalRate: 2, defense: 7, intelligence: 4, dexterity: 4),
			new Item("Overlord's Cudgel", ItemSlot.Weapon, attak: 43, magicAttak: 43, accuracy: 21, criticalRate: 2, strength: 4, intelligence: 4),
			new Item("Terros' Wand", ItemSlot.Weapon, attak: 5, magicAttak: 53, accuracy: 51, criticalRate: 2, intelligence: 3, dexterity: 3),
		};
		
		public static Item[] Clothworker = new Item[] {
			new Item("Beast Hood", ItemSlot.Helm, defense: 24, magicDefense: 24, hp: 15, dexterity: 3),
			new Item("Necro Robe", ItemSlot.Chest, defense: 18, magicDefense: 57),
			new Item("Beast Boots", ItemSlot.Boots, defense: 17, magicDefense: 17, hp: 10, dexterity: 2),
			new Item("Beast Gloves", ItemSlot.Gloves, defense: 17, magicDefense: 17, hp: 10, dexterity: 2),
			new Item("Necro Hat", ItemSlot.Helm, defense: 15, magicDefense: 34),
			new Item("Overlord's Robe", ItemSlot.Chest, defense: 21, magicDefense: 56, accuracy: 5, hp: 15, intelligence: 4),
			new Item("Ares' Gloves", ItemSlot.Gloves, defense: 19, magicDefense: 19, strength: 2, dexterity: 2),
			new Item("Gnoll Tunic", ItemSlot.Chest, defense: 39, magicDefense: 39, criticalRate: 5, dexterity: 3),
			new Item("Shaman's Hat", ItemSlot.Helm, defense: 17, magicDefense: 35, intelligence: 2, dexterity: 2),
			new Item("Gnoll Hood", ItemSlot.Helm, defense: 27, magicDefense: 27, criticalRate: 4, dexterity: 2),
			new Item("Gnoll Boots", ItemSlot.Boots, defense: 18, magicDefense: 18, criticalRate: 3, dexterity: 1),
			new Item("Gnoll Gloves", ItemSlot.Gloves, defense: 18, magicDefense: 18, criticalRate: 3, dexterity: 1),
			new Item("Worm Tunic", ItemSlot.Chest, defense: 37, magicDefense: 37, magicAttak: 5, accuracy: 5),
			new Item("Gnoll Crakows", ItemSlot.Boots, defense: 10, magicDefense: 22, hp: 7, intelligence: 1),
			new Item("Gnoll Mitts", ItemSlot.Gloves, defense: 10, magicDefense: 22, hp: 7, intelligence: 1),
		};

		public static Item[] Trinkets = new Item[] {
			new Item("Arachne's Ring", ItemSlot.Trinket, accuracy: 4),
			new Item("Grok's Amulet", ItemSlot.Trinket, attak: 4),
			new Item("Turtle Ring", ItemSlot.Trinket, magicDefense: 6),
			new Item("Lizard Amulet", ItemSlot.Trinket, criticalRate: 6),
			new Item("Ram Ring", ItemSlot.Trinket, strength: 2),
			new Item("Worm Ring", ItemSlot.Trinket, intelligence: 2),
			new Item("Gnoll Ring", ItemSlot.Trinket, dexterity: 2)
		};

	}
}
