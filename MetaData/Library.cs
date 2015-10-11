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
		
		public static ItemStereotype DaggerStereotype = new ItemStereotype(
							16, 4, 20, 5, 0, 0, 
							0.75, 0, 1.25, 5, 0, 0);
		public static ItemStereotype KnifeStereotype = new ItemStereotype(
							16, 4, 20, 5, 0, 0, 
							0.5, 0, 1.5, 5, 0, 0);
		public static ItemStereotype SwordStereotype = new ItemStereotype(
							18, 4, 18, 1, 0, 0, 
							1, 0, 1, 1, 0, 0);
		public static ItemStereotype LongswordStereotype = new ItemStereotype(
							18, 4, 18, 1, 0, 0, 
							1.25, 0, 0.75, 1, 0, 0);
		public static ItemStereotype HatchetStereotype = new ItemStereotype(
							21, 4, 13, 1, 0, 0, 
							1.5, 0, 0.5, 1, 0, 0);
		public static ItemStereotype AxeStereotype = new ItemStereotype(
							21, 4, 13, 1, 0, 0, 
							1.75, 0, 0.25, 1, 0, 0);
		public static ItemStereotype WandStereotype = new ItemStereotype(
							4, 19, 17, 1, 0, 0, 
							0, 1, 1, 1, 0, 0);
		public static ItemStereotype MysticWandStereotype = new ItemStereotype(
							4, 19, 17, 1, 0, 0, 
							0, 1.25, 0.75, 1, 0, 0);
		public static ItemStereotype ClubStereotype = new ItemStereotype(
							10, 16, 12, 1, 0, 0, 
							0.5, 1.25, 0.25, 1, 0, 0);
		public static ItemStereotype CudgelStereotype = new ItemStereotype(
							13, 13, 12, 1, 0, 0, 
							0.875, 0.875, 0.25, 1, 0, 0);
		public static ItemStereotype StaveStereotype = new ItemStereotype(
							4, 22, 12, 1, 0, 0, 
							0, 1.5, 0.5, 1, 0, 0);
		public static ItemStereotype MysticStaveStereotype = new ItemStereotype(
							4, 22, 12, 1, 0, 0, 
							0, 1.75, 0.25, 1, 0, 0);
		public static ItemStereotype RodStereotype = new ItemStereotype(
							8, 18, 12, 1, 0, 0, 
							0.5, 1, 0.5, 1, 0, 0);
		public static ItemStereotype PoleStereotype = new ItemStereotype(
							8, 15, 17, 1, 0, 0, 
							0.5, 0.75, 0.75, 1, 0, 0);
		public static ItemStereotype SpellswordStereotype = new ItemStereotype(
							16, 6, 18, 1, 0, 0, 
							0.75, 0.25, 1, 1, 0, 0);
		public static ItemStereotype HelmStereotype = new ItemStereotype(
							0, 0, 0, 0, 8, 4, 
							0, 0, 0, 0, 0.8, 0.4);
		public static ItemStereotype GreatHelmStereotype = new ItemStereotype(
							0, 0, 0, 0, 10, 2, 
							0, 0, 0, 0, 1, 0.2);
		public static ItemStereotype HoodStereotype = new ItemStereotype(
							0, 0, 0, 0, 6, 6, 
							0, 0, 0, 0, 0.6, 0.6);
		public static ItemStereotype HatStereotype = new ItemStereotype(
							0, 0, 0, 0, 4, 8, 
							0, 0, 0, 0, 0.4, 0.8);
		public static ItemStereotype ChainmailStereotype = new ItemStereotype(
							0, 0, 0, 0, 12, 4, 
							0, 0, 0, 0, 1.4, 0.4);
		public static ItemStereotype PlatemailStereotype = new ItemStereotype(
							0, 0, 0, 0, 14, 2, 
							0, 0, 0, 0, 1.6, 0.2);
		public static ItemStereotype TunicStereotype = new ItemStereotype(
							0, 0, 0, 0, 8, 8, 
							0, 0, 0, 0, 0.9, 0.9);
		public static ItemStereotype RobeStereotype = new ItemStereotype(
							0, 0, 0, 0, 4, 12, 
							0, 0, 0, 0, 0.4, 1.4);
		public static ItemStereotype BracersStereotype = new ItemStereotype(
							0, 0, 0, 0, 6, 2, 
							0, 0, 0, 0, 0.4, 0.2);
		public static ItemStereotype GauntletsStereotype = new ItemStereotype(
							0, 0, 0, 0, 7, 1, 
							0, 0, 0, 0, 0.5, 0.1);
		public static ItemStereotype GlovesStereotype = new ItemStereotype(
							0, 0, 0, 0, 4, 4, 
							0, 0, 0, 0, 0.3, 0.3);
		public static ItemStereotype MittsStereotype = new ItemStereotype(
							0, 0, 0, 0, 2, 6, 
							0, 0, 0, 0, 0.2, 0.4);
		public static ItemStereotype GreavesStereotype = new ItemStereotype(
							0, 0, 0, 0, 6, 2, 
							0, 0, 0, 0, 0.4, 0.2);
		public static ItemStereotype SabatonsStereotype = new ItemStereotype(
							0, 0, 0, 0, 7, 1, 
							0, 0, 0, 0, 0.5, 0.1);
		public static ItemStereotype BootsStereotype = new ItemStereotype(
							0, 0, 0, 0, 4, 4, 
							0, 0, 0, 0, 0.3, 0.3);
		public static ItemStereotype CrakowsStereotype = new ItemStereotype(
							0, 0, 0, 0, 2, 6, 
							0, 0, 0, 0, 0.2, 0.4);

		public static Item[] Blacksmith = new Item[] {
			new Item("Beast Hatchet", 37, ItemSlot.Weapon, attack: 81, magicAttack: 5, accuracy: 34, criticalRate: 2, dexterity: 3, hp: 25),
			new Item("Beast Sword", 36, ItemSlot.Weapon, attack: 65, magicAttack: 5, accuracy: 65, criticalRate: 2, dexterity: 3, hp: 25),
			new Item("Darksteel Axe", 35, ItemSlot.Weapon, attack: 80, magicAttack: 5, accuracy: 23, criticalRate: 2),
			new Item("Darksteel Longsword", 34, ItemSlot.Weapon, attack: 65, magicAttack: 5, accuracy: 62, criticalRate: 2),
			new Item("Darksteel Knife", 33, ItemSlot.Weapon, attack: 56, magicAttack: 5, accuracy: 67, criticalRate: 10),
			new Item("Darksteel Hatchet", 33, ItemSlot.Weapon, attack: 75, magicAttack: 5, accuracy: 32, criticalRate: 2),
			new Item("Darksteel Sword", 32, ItemSlot.Weapon, attack: 61, magicAttack: 5, accuracy: 61, criticalRate: 2),
			new Item("Darksteel Dagger", 31, ItemSlot.Weapon, attack: 54, magicAttack: 5, accuracy: 65, criticalRate: 10),
			new Item("Battlelord's Blade", 29, ItemSlot.Weapon, attack: 58 + 7, magicAttack: 5, accuracy: 58 + 7, criticalRate: 2, strength: 5),
			new Item("Overlord's Battleaxe", 29, ItemSlot.Weapon, attack: 75, magicAttack: 5, accuracy: 22, criticalRate: 2 + 7, strength: 4),
			new Item("Ceros' Knife", 28, ItemSlot.Weapon, defense: 7, attack: 50, magicAttack: 5, accuracy: 61, criticalRate: 10, strength: 4),
			new Item("Gnoll Axe", 28, ItemSlot.Weapon, attack: 73 + 5, magicAttack: 5, accuracy: 21, criticalRate: 2, dexterity: 3),
			new Item("Gnoll Longsword", 27, ItemSlot.Weapon, attack: 56 + 5, magicAttack: 5, accuracy: 48, criticalRate: 2, dexterity: 3),
			new Item("Ram Hatchet", 27, ItemSlot.Weapon, defense: 5, attack: 67 + 5, magicAttack: 5, accuracy: 29, criticalRate: 2),
			new Item("Gnoll Knife", 26, ItemSlot.Weapon, attack: 48 + 5, magicAttack: 5, accuracy: 59, criticalRate: 10, dexterity: 3),
			new Item("Ram Sword", 26, ItemSlot.Weapon, defense: 5, attack: 52 + 5, magicAttack: 5, accuracy: 52, criticalRate: 2),
			new Item("Adaman Axe", 25, ItemSlot.Weapon, attack: 68, magicAttack: 5, accuracy: 21, criticalRate: 2),
			new Item("Adaman Longsword", 24, ItemSlot.Weapon, attack: 54, magicAttack: 5, accuracy: 46, criticalRate: 2),
			new Item("Adaman Knife", 23, ItemSlot.Weapon, attack: 46, magicAttack: 5, accuracy: 57, criticalRate: 10),
			new Item("Adaman Hatchet", 23, ItemSlot.Weapon, attack: 62, magicAttack: 5, accuracy: 27, criticalRate: 2),
			new Item("Adaman Sword", 22, ItemSlot.Weapon, attack: 48, magicAttack: 5, accuracy: 48, criticalRate: 2),
			new Item("Adaman Dagger", 21, ItemSlot.Weapon, attack: 44, magicAttack: 5, accuracy: 51, criticalRate: 10),
			new Item("Prime Battleaxe", 19, ItemSlot.Weapon, attack: 57, magicAttack: 5, accuracy: 21, criticalRate: 2 + 5, strength: 3),
			new Item("Basamus' Sword", 18, ItemSlot.Weapon, attack: 43, magicAttack: 5, accuracy: 43, criticalRate: 2, strength: 3),
			new Item("Thief's Knife", 18, ItemSlot.Weapon, attack: 34, magicAttack: 5, accuracy: 50, criticalRate: 10),
			new Item("Murlok Axe", 18, ItemSlot.Weapon, attack: 55, magicAttack: 5, accuracy: 20 + 5, criticalRate: 2),
			new Item("Water Spellsword", 17, ItemSlot.Weapon, attack: 31, magicAttack: 13 + 5, accuracy: 38, criticalRate: 2),
			new Item("Lizard Hatchet", 17, ItemSlot.Weapon, attack: 49 + 5, magicAttack: 5, accuracy: 23, criticalRate: 2),
			new Item("Murlok Longsword", 17, ItemSlot.Weapon, attack: 42, magicAttack: 5, accuracy: 33 + 5, criticalRate: 2),
			new Item("Murlok Knife", 16, ItemSlot.Weapon, attack: 32, magicAttack: 5, accuracy: 47 + 5, criticalRate: 10),
			new Item("Lizard Dagger", 15, ItemSlot.Weapon, attack: 31 + 5, magicAttack: 5, accuracy: 42, criticalRate: 10),
			new Item("Turtle Sword", 15, ItemSlot.Weapon, attack: 36, magicAttack: 5, accuracy: 36, criticalRate: 2, hp: 12),
			new Item("Mithril Axe", 15, ItemSlot.Weapon, attack: 50, magicAttack: 5, accuracy: 20, criticalRate: 2),
			new Item("Mithril Longsword", 14, ItemSlot.Weapon, attack: 38, magicAttack: 5, accuracy: 31, criticalRate: 2),
			new Item("Mithril Knife", 13, ItemSlot.Weapon, attack: 29, magicAttack: 5, accuracy: 43, criticalRate: 10),
			new Item("Mithril Hatchet", 13, ItemSlot.Weapon, attack: 43, magicAttack: 5, accuracy: 22, criticalRate: 2),
			new Item("Mithril Sword", 12, ItemSlot.Weapon, attack: 33, magicAttack: 5, accuracy: 32, criticalRate: 2),
			new Item("Mithril Dagger", 11, ItemSlot.Weapon, attack: 27, magicAttack: 5, accuracy: 36, criticalRate: 10),
			new Item("Bloody Axe", 9, ItemSlot.Weapon, attack: 38, magicAttack: 5, accuracy: 17 + 3, criticalRate: 2, strength: 1),
			new Item("Chieftain's Longsword", 8, ItemSlot.Weapon, attack: 30, magicAttack: 5, accuracy: 26, criticalRate: 2, strength: 1),
			new Item("Venom's Knife", 8, ItemSlot.Weapon, attack: 26, magicAttack: 5 + 3, accuracy: 34, criticalRate: 10, dexterity: 1),
			new Item("Goblin Hatchet", 7, ItemSlot.Weapon, attack: 33 + 3, magicAttack: 5, accuracy: 18, criticalRate: 2),
			new Item("Goblin Sword", 6, ItemSlot.Weapon, attack: 26 + 3, magicAttack: 5, accuracy: 26, criticalRate: 2),
			new Item("Fang Hatchet", 6, ItemSlot.Weapon, attack: 32, magicAttack: 5, accuracy: 18, criticalRate: 2 + 3),
			new Item("Boar Sword", 5, ItemSlot.Weapon, defense: 3, attack: 25, magicAttack: 5, accuracy: 25, criticalRate: 2),
			new Item("Fang Knife", 5, ItemSlot.Weapon, attack: 24, magicAttack: 5, accuracy: 29, criticalRate: 10 + 3),
			new Item("Iron Axe", 5, ItemSlot.Weapon, attack: 31, magicAttack: 5, accuracy: 16, criticalRate: 2),
			new Item("Iron Longsword", 4, ItemSlot.Weapon, attack: 25, magicAttack: 5, accuracy: 23, criticalRate: 2),
			new Item("Iron Knife", 3, ItemSlot.Weapon, attack: 22, magicAttack: 5, accuracy: 27, criticalRate: 10),
			new Item("Iron Hatchet", 3, ItemSlot.Weapon, attack: 27, magicAttack: 5, accuracy: 16, criticalRate: 2),
			new Item("Iron Sword", 2, ItemSlot.Weapon, attack: 22, magicAttack: 5, accuracy: 22, criticalRate: 2),
			new Item("Iron Dagger", 1, ItemSlot.Weapon, attack: 20, magicAttack: 5, accuracy: 24, criticalRate: 10),
		};

		public static Item[] Armorsmith = new Item[] {
			new Item("Scorpion Platemail", 37, ItemSlot.Chest, magicAttack: 9, defense: 73, magicDefense: 11, strength: 4),
			new Item("Scorpion Great Helm", 36, ItemSlot.Helm, magicAttack: 7, defense: 49, magicDefense: 10, strength: 3),
			new Item("Darksteel Platemail", 36, ItemSlot.Chest, defense: 71, magicDefense: 11),
			new Item("Scorpion Sabatons", 35, ItemSlot.Boots, magicAttack: 5, defense: 28, magicDefense: 8, strength: 2),
			new Item("Scorpion Gauntlets", 35, ItemSlot.Gloves, magicAttack: 5, defense: 28, magicDefense: 8, strength: 2),
			new Item("Darksteel Great Helm", 35, ItemSlot.Helm, defense: 48, magicDefense: 10),
			new Item("Darksteel Sabatons", 34, ItemSlot.Boots, defense: 27, magicDefense: 8),
			new Item("Darksteel Gauntlets", 34, ItemSlot.Gloves, defense: 27, magicDefense: 8),
			new Item("Darksteel Chainmail", 33, ItemSlot.Chest, defense: 62, magicDefense: 20),
			new Item("Darksteel Helm", 32, ItemSlot.Helm, defense: 39, magicDefense: 18),
			new Item("Darksteel Greaves", 31, ItemSlot.Boots, defense: 23, magicDefense: 10),
			new Item("Darksteel Bracers", 31, ItemSlot.Gloves, defense: 23, magicDefense: 10),
			new Item("Ares' Helm", 29, ItemSlot.Helm, attack: 5, defense: 36 + 5, magicDefense: 17, strength: 4),
			new Item("Ares' Bracers", 29, ItemSlot.Gloves, defense: 22 + 7, magicDefense: 9, strength: 2),
			new Item("Gnoll Chainmail", 29, ItemSlot.Chest, criticalRate: 4, defense: 58, magicDefense: 19, strength: 3),
			new Item("Fighters Greaves", 28, ItemSlot.Boots, defense: 22, magicDefense: 9, strength: 2, dexterity: 2),
			new Item("Gnoll Helm", 28, ItemSlot.Helm, criticalRate: 4, defense: 35, magicDefense: 16, strength: 2),
			new Item("Gnoll Platemail", 28, ItemSlot.Chest, attack: 5, defense: 64, magicDefense: 10, dexterity: 3),
			new Item("Gnoll Greaves", 27, ItemSlot.Boots, criticalRate: 3, defense: 21, magicDefense: 9, strength: 1),
			new Item("Gnoll Bracers", 27, ItemSlot.Gloves, criticalRate: 3, defense: 21, magicDefense: 9, strength: 1),
			new Item("Gnoll Great Helm", 27, ItemSlot.Helm, attack: 4, defense: 42, magicDefense: 9, dexterity: 2),
			new Item("Ram Chainmail", 27, ItemSlot.Chest, attack: 5, defense: 55 + 5, magicDefense: 18),
			new Item("Gnoll Sabatons", 26, ItemSlot.Boots, attack: 3, defense: 24, magicDefense: 7, dexterity: 1),
			new Item("Gnoll Gauntlets", 26, ItemSlot.Gloves, attack: 3, defense: 24, magicDefense: 7, dexterity: 1),
			new Item("Adaman Platemail", 26, ItemSlot.Chest, defense: 60, magicDefense: 9),
			new Item("Ram Helm", 26, ItemSlot.Helm, attack: 4, defense: 33 + 4, magicDefense: 16),
			new Item("Ram Greaves", 25, ItemSlot.Boots, attack: 3, defense: 20 + 3, magicDefense: 8),
			new Item("Ram Bracers", 25, ItemSlot.Gloves, attack: 3, defense: 20 + 3, magicDefense: 8),
			new Item("Adaman Great Helm", 25, ItemSlot.Helm, defense: 40, magicDefense: 8),
			new Item("Adaman Sabatons", 24, ItemSlot.Boots, defense: 22, magicDefense: 6),
			new Item("Adaman Gauntlets", 24, ItemSlot.Gloves, defense: 22, magicDefense: 6),
			new Item("Adaman Chainmail", 23, ItemSlot.Chest, defense: 50, magicDefense: 16),
			new Item("Adaman Helm", 22, ItemSlot.Helm, defense: 29, magicDefense: 15),
			new Item("Adaman Greaves", 21, ItemSlot.Boots, defense: 18, magicDefense: 8),
			new Item("Adaman Bracers", 21, ItemSlot.Gloves, defense: 18, magicDefense: 8),
			new Item("Shellmail", 19, ItemSlot.Chest, defense: 47 + 4, magicDefense: 7 + 4, hp: 15),
			new Item("Warleader's Gauntlets", 18, ItemSlot.Gloves, attack: 4, defense: 18, magicDefense: 4, strength: 2),
			new Item("Murlok Chainmail", 18, ItemSlot.Chest, defense: 40, magicDefense: 13, dexterity: 2),
			new Item("Assault Helm", 18, ItemSlot.Helm, attack: 4, accuracy: 4, defense: 25, magicDefense: 13),
			new Item("Turtle Platemail", 17, ItemSlot.Chest, defense: 44, magicDefense: 6, hp: 15),
			new Item("Murlok Helm", 17, ItemSlot.Helm, accuracy: 5, defense: 24, magicDefense: 13),
			new Item("Heavy Greaves", 17, ItemSlot.Boots, defense: 15, magicDefense: 7 + 4),
			new Item("Heavy Bracers", 17, ItemSlot.Gloves, defense: 15, magicDefense: 7 + 4),
			new Item("Turtle Great Helm", 16, ItemSlot.Helm, defense: 29, magicDefense: 6, hp: 12),
			new Item("Lizard Greaves", 16, ItemSlot.Boots, attack: 4, defense: 14, magicDefense: 7),
			new Item("Lizard Bracers", 16, ItemSlot.Gloves, attack: 4, defense: 14, magicDefense: 7),
			new Item("Mithril Platemail", 16, ItemSlot.Chest, defense: 42, magicDefense: 6),
			new Item("Turtle Sabatons", 15, ItemSlot.Boots, defense: 17, magicDefense: 4, hp: 7),
			new Item("Turtle Gauntlets", 15, ItemSlot.Gloves, defense: 17, magicDefense: 4, hp: 7),
			new Item("Mithril Great Helm", 15, ItemSlot.Helm, defense: 28, magicDefense: 6),
			new Item("Mithril Sabatons", 14, ItemSlot.Boots, defense: 16, magicDefense: 4),
			new Item("Mithril Gauntlets", 14, ItemSlot.Gloves, defense: 16, magicDefense: 4),
			new Item("Mithril Chainmail", 13, ItemSlot.Chest, defense: 33, magicDefense: 11),
			new Item("Mithril Helm", 12, ItemSlot.Helm, defense: 21, magicDefense: 11),
			new Item("Mithril Greaves", 11, ItemSlot.Boots, defense: 13, magicDefense: 6),
			new Item("Mithril Bracers", 11, ItemSlot.Gloves, defense: 13, magicDefense: 6),
			new Item("Gronok's Platemail", 9, ItemSlot.Chest, defense: 29, magicDefense: 4, strength: 1, hp: 7),
			new Item("Goblin Platemail", 8, ItemSlot.Chest, defense: 28, magicDefense: 4, hp: 10),
			new Item("Enchanted Helm", 8, ItemSlot.Helm, defense: 16, magicDefense: 8 + 4),
			new Item("Hogger's Bracers", 7, ItemSlot.Gloves, attack: 5, defense: 11, magicDefense: 3),
			new Item("Goblin Great Helm", 7, ItemSlot.Helm, defense: 19, magicDefense: 3, hp: 7),
			new Item("Boar Chainmail", 7, ItemSlot.Chest, defense: 24 + 4, magicDefense: 8),
			new Item("Goblin Sabatons", 6, ItemSlot.Boots, defense: 11, magicDefense: 2, hp: 4),
			new Item("Goblin Gauntlets", 6, ItemSlot.Gloves, defense: 11, magicDefense: 2, hp: 4),
			new Item("Boar Helm", 6, ItemSlot.Helm, defense: 15 + 3, magicDefense: 8),
			new Item("Iron Platemail", 6, ItemSlot.Chest, defense: 25, magicDefense: 3),
			new Item("Boar Greaves", 5, ItemSlot.Boots, defense: 9 + 2, magicDefense: 4),
			new Item("Boar Bracers", 5, ItemSlot.Gloves, defense: 9 + 2, magicDefense: 4),
			new Item("Scale Greaves", 5, ItemSlot.Boots, attack: 2, defense: 9, magicDefense: 4),
			new Item("Scale Bracers", 5, ItemSlot.Gloves, attack: 2, defense: 9, magicDefense: 4),
			new Item("Iron Great Helm", 5, ItemSlot.Helm, defense: 17, magicDefense: 3),
			new Item("Iron Sabatons", 4, ItemSlot.Boots, defense: 10, magicDefense: 2),
			new Item("Iron Gauntlets", 4, ItemSlot.Gloves, defense: 10, magicDefense: 2),
			new Item("Iron Chainmail", 3, ItemSlot.Chest, defense: 18, magicDefense: 6),
			new Item("Iron Helm", 2, ItemSlot.Helm, defense: 11, magicDefense: 6),
			new Item("Iron Greaves", 1, ItemSlot.Boots, defense: 7, magicDefense: 3),
			new Item("Iron Bracers", 1, ItemSlot.Gloves, defense: 7, magicDefense: 3),
		};
		
		public static Item[] Woodworker = new Item[] {
			new Item("Scorpion Cudgel", 37, ItemSlot.Weapon, attack: 56 + 7, magicAttack: 56, accuracy: 22, criticalRate: 2, intelligence: 3),
			new Item("Scorpion Wand", 36, ItemSlot.Weapon, attack: 5 + 7, magicAttack: 68, accuracy: 61, criticalRate: 2, intelligence: 3),
			new Item("Deadwood Mystic Stave", 35, ItemSlot.Weapon, attack: 5, magicAttack: 85, accuracy: 22, criticalRate: 2),
			new Item("Deadwood Cudgel", 34, ItemSlot.Weapon, attack: 52, magicAttack: 52, accuracy: 21, criticalRate: 2),
			new Item("Deadwood Mystic Wand", 33, ItemSlot.Weapon, attack: 5, magicAttack: 67, accuracy: 57, criticalRate: 2),
			new Item("Deadwood Stave", 33, ItemSlot.Weapon, attack: 5, magicAttack: 79, accuracy: 30, criticalRate: 2),
			new Item("Deadwood Club", 32, ItemSlot.Weapon, attack: 32, magicAttack: 66, accuracy: 21, criticalRate: 2),
			new Item("Deadwood Wand", 31, ItemSlot.Weapon, attack: 5, magicAttack: 63, accuracy: 56, criticalRate: 2),
			new Item("Ares' Stave", 29, ItemSlot.Weapon, defense: 7, attack: 5, magicAttack: 75, accuracy: 28, criticalRate: 2, intelligence: 4, dexterity: 4),
			new Item("Overlord's Cudgel", 29, ItemSlot.Weapon, attack: 43, magicAttack: 43, accuracy: 21, criticalRate: 2, strength: 4, intelligence: 4),
			new Item("Terros' Wand", 28, ItemSlot.Weapon, attack: 5, magicAttack: 53, accuracy: 51, criticalRate: 2, intelligence: 3, dexterity: 3),
			new Item("Gnoll Mystic Stave", 28, ItemSlot.Weapon, attack: 5, magicAttack: 74, accuracy: 21, criticalRate: 2, intelligence: 2, hp: 15),
			new Item("Gnoll Cudgel", 27, ItemSlot.Weapon, attack: 41, magicAttack: 41, accuracy: 20, criticalRate: 2, intelligence: 2, hp: 15),
			new Item("Worm Stave", 27, ItemSlot.Weapon, attack: 5, magicAttack: 67 + 5, accuracy: 27 + 5, criticalRate: 2),
			new Item("Gnoll Mystic Wand", 26, ItemSlot.Weapon, attack: 5, magicAttack: 54, accuracy: 45, criticalRate: 2, intelligence: 2, hp: 15),
			new Item("Worm Wand", 25, ItemSlot.Weapon, attack: 5, magicAttack: 51 + 5, accuracy: 49 + 5, criticalRate: 2),
			new Item("Oak Mystic Stave", 25, ItemSlot.Weapon, attack: 5, magicAttack: 69, accuracy: 20, criticalRate: 2),
			new Item("Oak Cudgel", 24, ItemSlot.Weapon, attack: 39, magicAttack: 39, accuracy: 19, criticalRate: 2),
			new Item("Oak Mystic Wand", 23, ItemSlot.Weapon, attack: 5, magicAttack: 52, accuracy: 43, criticalRate: 2),
			new Item("Oak Stave", 23, ItemSlot.Weapon, attack: 5, magicAttack: 63, accuracy: 26, criticalRate: 2),
			new Item("Oak Club", 22, ItemSlot.Weapon, attack: 24, magicAttack: 48, accuracy: 19, criticalRate: 2),
			new Item("Oak Wand", 21, ItemSlot.Weapon, attack: 5, magicAttack: 47, accuracy: 45, criticalRate: 2),
			new Item("Demolisher's Mace", 19, ItemSlot.Weapon, attack: 32, magicAttack: 32, accuracy: 19, criticalRate: 2, strength: 3, intelligence: 3),
			new Item("Priest's Stave", 19, ItemSlot.Weapon, attack: 5, magicAttack: 53, accuracy: 24 + 5, criticalRate: 2, intelligence: 3),
			new Item("Tidecaller's Wand", 18, ItemSlot.Weapon, attack: 5, magicAttack: 40, accuracy: 38, criticalRate: 2, intelligence: 2, hp: 12),
			new Item("Murlok Pole", 18, ItemSlot.Weapon, attack: 20, magicAttack: 39, accuracy: 24 + 5, criticalRate: 2),
			new Item("Lizard Cudgel", 17, ItemSlot.Weapon, attack: 30 + 5, magicAttack: 30, accuracy: 19, criticalRate: 2),
			new Item("Murlok Rod", 17, ItemSlot.Weapon, attack: 19, magicAttack: 30, accuracy: 32 + 5, criticalRate: 2),
			new Item("Murlok Mystic Stave", 17, ItemSlot.Weapon, attack: 5, magicAttack: 54 + 5, accuracy: 19, criticalRate: 2),
			new Item("Murlok Club", 16, ItemSlot.Weapon, attack: 21, magicAttack: 40 + 5, accuracy: 19, criticalRate: 2),
			new Item("Murlok Mystic Wand", 15, ItemSlot.Weapon, attack: 5, magicAttack: 40 + 5, accuracy: 31, criticalRate: 2),
			new Item("Turtle Club", 15, ItemSlot.Weapon, attack: 20, magicAttack: 39, accuracy: 19, criticalRate: 2, hp: 12),
			new Item("Willow Mystic Stave", 15, ItemSlot.Weapon, attack: 5, magicAttack: 51, accuracy: 19, criticalRate: 2),
			new Item("Willow Cudgel", 14, ItemSlot.Weapon, attack: 28, magicAttack: 28, accuracy: 18, criticalRate: 2),
			new Item("Willow Mystic Wand", 13, ItemSlot.Weapon, attack: 5, magicAttack: 38, accuracy: 29, criticalRate: 2),
			new Item("Willow Stave", 13, ItemSlot.Weapon, attack: 5, magicAttack: 43, accuracy: 21, criticalRate: 2),
			new Item("Willow Club", 12, ItemSlot.Weapon, attack: 16, magicAttack: 34, accuracy: 18, criticalRate: 2),
			new Item("Willow Wand", 11, ItemSlot.Weapon, attack: 5, magicAttack: 33, accuracy: 31, criticalRate: 2),
			new Item("Bloody Club", 9, ItemSlot.Weapon, attack: 16, magicAttack: 29, accuracy: 16 + 3, criticalRate: 2, intelligence: 1),
			new Item("Maexna's Mystic Wand", 8, ItemSlot.Weapon, attack: 5, magicAttack: 31, accuracy: 25, criticalRate: 2, intelligence: 1),
			new Item("Goblin Mystic Stave", 8, ItemSlot.Weapon, attack: 5, magicAttack: 38 + 3, accuracy: 16, criticalRate: 2),
			new Item("Goblin Cudgel", 7, ItemSlot.Weapon, attack: 21 + 2, magicAttack: 21 + 2, accuracy: 15, criticalRate: 2),
			new Item("Spider Stave", 7, ItemSlot.Weapon, attack: 5, magicAttack: 34, accuracy: 17 + 3, criticalRate: 2),
			new Item("Goblin Wand", 6, ItemSlot.Weapon, attack: 5, magicAttack: 27 + 3, accuracy: 25, criticalRate: 2),
			new Item("Boar Club", 6, ItemSlot.Weapon, defense: 3, attack: 15, magicAttack: 25, accuracy: 15, criticalRate: 2),
			new Item("Spider Wand", 5, ItemSlot.Weapon, attack: 5, magicAttack: 26, accuracy: 24 + 4, criticalRate: 2),
			new Item("Ashe Mystic Stave", 5, ItemSlot.Weapon, attack: 5, magicAttack: 32, accuracy: 15, criticalRate: 2),
			new Item("Ashe Cudgel", 4, ItemSlot.Weapon, attack: 18, magicAttack: 18, accuracy: 15, criticalRate: 2),
			new Item("Ashe Mystic Wand", 3, ItemSlot.Weapon, attack: 5, magicAttack: 25, accuracy: 21, criticalRate: 2),
			new Item("Ashe Stave", 3, ItemSlot.Weapon, attack: 5, magicAttack: 28, accuracy: 14, criticalRate: 2),
			new Item("Ashe Club", 2, ItemSlot.Weapon, attack: 13, magicAttack: 20, accuracy: 14, criticalRate: 2),
			new Item("Ashe Wand", 1, ItemSlot.Weapon, attack: 5, magicAttack: 22, accuracy: 20, criticalRate: 2),
		};
		
		public static Item[] Clothworker = new Item[] {
			new Item("Beast Tunic", 38, ItemSlot.Chest, defense: 48, magicDefense: 48, dexterity: 4, hp: 25),
			new Item("Beast Hood", 37, ItemSlot.Helm, defense: 31, magicDefense: 31, dexterity: 3, hp: 15),
			new Item("Necro Robe", 36, ItemSlot.Chest, defense: 24, magicDefense: 65),
			new Item("Beast Boots", 36, ItemSlot.Boots, defense: 22, magicDefense: 22, dexterity: 2, hp: 10),
			new Item("Beast Gloves", 36, ItemSlot.Gloves, defense: 22, magicDefense: 22, dexterity: 2, hp: 10),
			new Item("Necro Hat", 35, ItemSlot.Helm, defense: 19, magicDefense: 40),
			new Item("Necro Crakows", 34, ItemSlot.Boots, defense: 11, magicDefense: 26),
			new Item("Necro Mitts", 34, ItemSlot.Gloves, defense: 11, magicDefense: 26),
			new Item("Necro Tunic", 33, ItemSlot.Chest, defense: 43, magicDefense: 43),
			new Item("Necro Hood", 32, ItemSlot.Helm, defense: 29, magicDefense: 29),
			new Item("Necro Boots", 31, ItemSlot.Boots, defense: 20, magicDefense: 20),
			new Item("Necro Gloves", 31, ItemSlot.Gloves, defense: 20, magicDefense: 20),
			new Item("Overlord's Robe", 29, ItemSlot.Chest, accuracy: 5, defense: 21, magicDefense: 56, intelligence: 4, hp: 25),
			new Item("Ares' Gloves", 29, ItemSlot.Gloves, defense: 19, magicDefense: 19, strength: 2, dexterity: 2),
			new Item("Gnoll Tunic", 29, ItemSlot.Chest, criticalRate: 5, defense: 39, magicDefense: 39, dexterity: 3),
			new Item("Shaman's Hat", 28, ItemSlot.Helm, defense: 17, magicDefense: 35, intelligence: 2, dexterity: 2),
			new Item("Gnoll Hood", 28, ItemSlot.Helm, criticalRate: 4, defense: 27, magicDefense: 27, dexterity: 2),
			new Item("Gnoll Robe", 28, ItemSlot.Chest, defense: 20, magicDefense: 55, intelligence: 3, hp: 15),
			new Item("Gnoll Boots", 27, ItemSlot.Boots, criticalRate: 3, defense: 18, magicDefense: 18, dexterity: 1),
			new Item("Gnoll Gloves", 27, ItemSlot.Gloves, criticalRate: 3, defense: 18, magicDefense: 18, dexterity: 1),
			new Item("Gnoll Hat", 28, ItemSlot.Helm, defense: 16, magicDefense: 34, intelligence: 2, hp: 12),
			new Item("Worm Tunic", 27, ItemSlot.Chest, magicAttack: 5, accuracy: 5, defense: 37, magicDefense: 37),
			new Item("Gnoll Crakows", 26, ItemSlot.Boots, defense: 10, magicDefense: 22, intelligence: 1, hp: 7),
			new Item("Gnoll Mitts", 26, ItemSlot.Gloves, defense: 10, magicDefense: 22, intelligence: 1, hp: 10),
			new Item("Cashmere Robe", 26, ItemSlot.Chest, defense: 19, magicDefense: 52),
			new Item("Worm Hood", 26, ItemSlot.Helm, magicAttack: 4, accuracy: 4, defense: 25, magicDefense: 25),
			new Item("Worm Boots", 25, ItemSlot.Boots, magicAttack: 3, accuracy: 3, defense: 17, magicDefense: 17),
			new Item("Worm Gloves", 25, ItemSlot.Gloves, magicAttack: 3, accuracy: 3, defense: 17, magicDefense: 17),
			new Item("Cashmere Hat", 25, ItemSlot.Helm, defense: 15, magicDefense: 32),
			new Item("Cashmere Crakows", 24, ItemSlot.Boots, defense: 9, magicDefense: 21),
			new Item("Cashmere Mitts", 24, ItemSlot.Gloves, defense: 9, magicDefense: 21),
			new Item("Cashmere Tunic", 23, ItemSlot.Chest, defense: 34, magicDefense: 34),
			new Item("Cashmere Hood", 22, ItemSlot.Helm, defense: 24, magicDefense: 24),
			new Item("Cashmere Boots", 21, ItemSlot.Boots, defense: 15, magicDefense: 15),
			new Item("Cashmere Gloves", 21, ItemSlot.Gloves, defense: 15, magicDefense: 15),
			new Item("Priest's Hat", 19, ItemSlot.Helm, accuracy: 3, defense: 13, magicDefense: 26, intelligence: 2),
			new Item("Reinforced Tunic", 18, ItemSlot.Chest, defense: 27 + 5, magicDefense: 27),
			new Item("Lizard Tunic", 18, ItemSlot.Chest, defense: 27, magicDefense: 27, strength: 2),
			new Item("Leaping Boots", 18, ItemSlot.Boots, criticalRate: 3, defense: 12, magicDefense: 12, dexterity: 2),
			new Item("Murlok Robe", 17, ItemSlot.Chest, defense: 13, magicDefense: 38, intelligence: 2),
			new Item("Lizard Hood", 17, ItemSlot.Helm, attack: 5, defense: 19, magicDefense: 19),
			new Item("Deadly Boots", 17, ItemSlot.Boots, attack: 3, magicAttack: 3, defense: 11, magicDefense: 11),
			new Item("Deadly Gloves", 17, ItemSlot.Gloves, attack: 3, magicAttack: 3, defense: 11, magicDefense: 11),
			new Item("Murlok Hat", 16, ItemSlot.Helm, magicAttack: 5, defense: 12, magicDefense: 23),
			new Item("Murlok Boots", 16, ItemSlot.Boots, accuracy: 4, defense: 11, magicDefense: 11),
			new Item("Murlok Gloves", 16, ItemSlot.Gloves, accuracy: 4, defense: 11, magicDefense: 11),
			new Item("Silk Robe", 16, ItemSlot.Chest, defense: 12, magicDefense: 37),
			new Item("Murlok Crakows", 15, ItemSlot.Boots, magicAttack: 4, defense: 7, magicDefense: 14),
			new Item("Murlok Mitts", 15, ItemSlot.Gloves, magicAttack: 4, defense: 7, magicDefense: 14),
			new Item("Silk Hat", 15, ItemSlot.Helm, defense: 12, magicDefense: 23),
			new Item("Silk Crakows", 14, ItemSlot.Boots, defense: 7, magicDefense: 13),
			new Item("Silk Mitts", 14, ItemSlot.Gloves, defense: 7, magicDefense: 13),
			new Item("Silk Tunic", 13, ItemSlot.Chest, defense: 22, magicDefense: 22),
			new Item("Silk Hood", 12, ItemSlot.Helm, defense: 16, magicDefense: 16),
			new Item("Silk Boots", 11, ItemSlot.Boots, defense: 9, magicDefense: 9),
			new Item("Silk Gloves", 11, ItemSlot.Gloves, defense: 9, magicDefense: 9),
			new Item("Gronok's Tunic", 9, ItemSlot.Chest, defense: 18, magicDefense: 18, dexterity: 1, hp: 7),
			new Item("Siru's Hat", 8, ItemSlot.Helm, defense: 8, magicDefense: 16, intelligence: 1),
			new Item("Goblin Robe", 8, ItemSlot.Chest, magicAttack: 4, defense: 8, magicDefense: 25),
			new Item("Ranger Boots", 7, ItemSlot.Boots, criticalRate: 3, defense: 7, magicDefense: 7),
			new Item("Goblin Hat", 7, ItemSlot.Helm, magicAttack: 3, defense: 8, magicDefense: 15),
			new Item("Scale Tunic", 7, ItemSlot.Chest, attack: 4, defense: 16, magicDefense: 16),
			new Item("Goblin Crakows", 6, ItemSlot.Boots, magicAttack: 2, defense: 4, magicDefense: 9),
			new Item("Goblin Mitts", 6, ItemSlot.Gloves, magicAttack: 2, defense: 4, magicDefense: 9),
			new Item("Scale Hood", 6, ItemSlot.Helm, attack: 3, defense: 11, magicDefense: 11),
			new Item("Spider Robe", 6, ItemSlot.Chest, accuracy: 4, defense: 7, magicDefense: 22),
			new Item("Hempen Robe", 6, ItemSlot.Chest, defense: 7, magicDefense: 22),
			new Item("Spider Hat", 5, ItemSlot.Helm, accuracy: 3, defense: 7, magicDefense: 14),
			new Item("Hempen Hat", 5, ItemSlot.Helm, defense: 7, magicDefense: 14),
			new Item("Spider Crakows", 4, ItemSlot.Boots, accuracy: 2, defense: 4, magicDefense: 8),
			new Item("Spider Mitts", 4, ItemSlot.Gloves, accuracy: 2, defense: 4, magicDefense: 8),
			new Item("Hempen Crakows", 4, ItemSlot.Boots, defense: 4, magicDefense: 8),
			new Item("Hempen Mitts", 4, ItemSlot.Gloves, defense: 4, magicDefense: 8),
			new Item("Hempen Tunic", 3, ItemSlot.Chest, defense: 13, magicDefense: 13),
			new Item("Hempen Hood", 2, ItemSlot.Helm, defense: 9, magicDefense: 9),
			new Item("Hempen Boots", 1, ItemSlot.Boots, defense: 5, magicDefense: 5),
			new Item("Hempen Gloves", 1, ItemSlot.Gloves, defense: 5, magicDefense: 5),
		};

		public static Item[] Trinkets = new Item[] {
			new Item("Arachne's Ring", 3, ItemSlot.Trinket, accuracy: 4),
			new Item("Grok's Amulet", 5, ItemSlot.Trinket, attack: 4),
			new Item("Turtle Ring", 12, ItemSlot.Trinket, magicDefense: 6),
			new Item("Lizard Amulet", 12, ItemSlot.Trinket, criticalRate: 6),
			new Item("Ram Ring", 22, ItemSlot.Trinket, strength: 2),
			new Item("Worm Ring", 22, ItemSlot.Trinket, intelligence: 2),
			new Item("Gnoll Ring", 25, ItemSlot.Trinket, dexterity: 2)
		};

		public static Monster[] Monsters = new Monster[] {
			new Monster("Moss Golem", 2, 15, 5, 5, 10, 5, 40),
			new Monster("Forest Treant", 2, 5, 15, 5, 5, 10, 40),
			new Monster("Grass Spider", 3, 5, 20, 10, 5, 10, 50),
			new Monster("Arachne", 3, 5, 30, 15, 5, 10, 65),
			new Monster("Tuvale Viper", 4, 25, 5, 15, 10, 5, 60),
			new Monster("Venom", 4, 35, 10, 15, 10, 5, 70),
			new Monster("Wild Boar", 5, 20, 5, 5, 20, 5, 80),
			new Monster("Hogger", 5, 25, 5, 10, 30, 15, 100),
			new Monster("Goblin Footman", 6, 25, 5, 15, 25, 10, 100),
			new Monster("Grok The Mighty", 6, 35, 5, 20, 30, 10, 110),
			new Monster("Goblin Enchanter", 7, 5, 35, 10, 10, 15, 90),
			new Monster("Siru The Wise", 7, 5, 45, 10, 15, 25, 110),
			new Monster("Goblin Chieftain", 8, 40, 5, 20, 25, 15, 130),
			new Monster("Lord Gronok", 8, 50, 5, 25, 35, 15, 150),
			new Monster("Maexna", 9, 20, 40, 20, 20, 20, 250, maxPartyMembers: 2),
			new Monster("Queen Maexna", 9, 20, 55, 25, 20, 25, 280, maxPartyMembers: 2),
			new Monster("Coral Giant", 11, 30, 5, 15, 20, 20, 150),
			new Monster("Water Willow", 11, 5, 30, 15, 20, 20, 150),
			new Monster("Yarsol Snapper", 12, 20, 5, 10, 40, 30, 240),
			new Monster("Wild Turtle", 12, 30, 5, 15, 50, 35, 260),
			new Monster("Murlok Priest", 13, 10, 40, 30, 20, 20, 180),
			new Monster("Murlok Tidecaller", 13, 10, 50, 40, 20, 30, 200),
			new Monster("Sand Lizard", 14, 50, 5, 20, 30, 10, 200),
			new Monster("Leaping Lizzy", 14, 60, 5, 30, 40, 10, 220),
			new Monster("Murlok Spearman", 15, 50, 5, 30, 30, 10, 220),
			new Monster("Murlok Warleader", 15, 60, 5, 35, 35, 15, 240),
			new Monster("Murlok Assassin", 16, 55, 10, 50, 20, 10, 180),
			new Monster("Murlok Tidehunter", 16, 65, 10, 55, 30, 15, 190),
			new Monster("Murlok Highpriest", 17, 10, 70, 30, 20, 20, 220),
			new Monster("Prophet Nami", 17, 10, 80, 45, 25, 30, 250),
			new Monster("Basamus", 18, 110, 5, 30, 50, 30, 500, maxPartyMembers: 2),
			new Monster("Basamus Prime", 18, 130, 5, 30, 65, 35, 550, maxPartyMembers: 2),
			new Monster("Highland Titan", 21, 50, 5, 30, 40, 20, 250),
			new Monster("Aldur Gaurdian", 21, 5, 50, 30, 30, 30, 250),
			new Monster("Aldur Ram", 22, 65, 5, 40, 50, 20, 270),
			new Monster("Ceros", 22, 75, 5, 50, 60, 20, 290),
			new Monster("Highland Tunneler", 23, 10, 75, 50, 40, 30, 250),
			new Monster("Terros", 23, 10, 85, 55, 50, 40, 280),
			new Monster("Gnoll Hunter", 24, 75, 5, 60, 55, 15, 300),
			new Monster("Reygar", 24, 90, 5, 60, 60, 20, 320),
			new Monster("Gnoll Shaman", 25, 5, 80, 50, 35, 35, 280),
			new Monster("Kaldar", 25, 5, 100, 60, 40, 40, 290),
			new Monster("Gnoll Overlord", 26, 150, 10, 70, 80, 40, 1000, maxPartyMembers: 3),
			new Monster("Drahgar", 26, 180, 10, 80, 100, 50, 1200, maxPartyMembers: 3),
			new Monster("Ares", 27, 190, 20, 80, 100, 60, 900, maxPartyMembers: 3),
			new Monster("Ares Prime", 27, 220, 30, 90, 130, 70, 1000, maxPartyMembers: 3),
			new Monster("Dark Colossus", 31, 70, 5, 30, 50, 30, 320),
			new Monster("Haunted Harwood", 31, 5, 70, 30, 40, 40, 320),
			new Monster("Nightmare Scorpion", 32, 60, 80, 50, 100, 100, 750, maxPartyMembers: 2),
			new Monster("Night Beast", 33, 150, 20, 70, 120, 70, 900, maxPartyMembers: 2),
		};
	}
}
