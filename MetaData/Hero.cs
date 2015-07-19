using System;

namespace Merchant_RPG_build.MetaData
{
	public class Hero
	{
		public readonly string Name;
		public readonly double Strength;
		public readonly double Intelligence;
		public readonly double Dexterity;
		
		public readonly double StartHP;
		public readonly double StartAttak;
		public readonly double StartMagicAttak;
		public readonly double StartAccuracy;
		public readonly double StartCriticalRate;
		public readonly double StartDefense;
		public readonly double StartMagicDefense;
		
		public readonly double LevelHP;
		public readonly double LevelAttak;
		public readonly double LevelMagicAttak;
		public readonly double LevelAccuracy;
		public readonly double LevelCriticalRate;
		public readonly double LevelDefense;
		public readonly double LevelMagicDefense;
		
		public Hero(string name, double strength, double intelligence, double dexterity, double startHP, double startAttak, double startMagicAttak, double startAccuracy, double startCriticalRate, double startDefense, double startMagicDefense, double levelHP, double levelAttak, double levelMagicAttak, double levelAccuracy, double levelCriticalRate, double levelDefense, double levelMagicDefense)
		{
			this.Name = name;
			this.Strength = strength;
			this.Intelligence = intelligence;
			this.Dexterity = dexterity;
			this.StartHP = startHP;
			this.StartAttak = startAttak;
			this.StartMagicAttak = startMagicAttak;
			this.StartAccuracy = startAccuracy;
			this.StartCriticalRate = startCriticalRate;
			this.StartDefense = startDefense;
			this.StartMagicDefense = startMagicDefense;
			this.LevelHP = levelHP;
			this.LevelAttak = levelAttak;
			this.LevelMagicAttak = levelMagicAttak;
			this.LevelAccuracy = levelAccuracy;
			this.LevelCriticalRate = levelCriticalRate;
			this.LevelDefense = levelDefense;
			this.LevelMagicDefense = levelMagicDefense;
		}
	}
}
