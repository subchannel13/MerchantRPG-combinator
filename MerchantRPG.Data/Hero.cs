using System;

namespace MerchantRPG.Data
{
	public class Hero
	{
		public readonly string Name;
		public readonly double Strength;
		public readonly double Intelligence;
		public readonly double Dexterity;
		
		public readonly double StartHP;
		public readonly double StartAttack;
		public readonly double StartMagicAttack;
		public readonly double StartAccuracy;
		public readonly double StartCriticalRate;
		public readonly double StartDefense;
		public readonly double StartMagicDefense;
		
		public readonly double LevelHP;
		public readonly double LevelAttack;
		public readonly double LevelMagicAttack;
		public readonly double LevelAccuracy;
		public readonly double LevelCriticalRate;
		public readonly double LevelDefense;
		public readonly double LevelMagicDefense;
		
		public Hero(string name, double strength, double intelligence, double dexterity, double startHP, double startAttack, double startMagicAttack, double startAccuracy, double startCriticalRate, double startDefense, double startMagicDefense, double levelHP, double levelAttack, double levelMagicAttack, double levelAccuracy, double levelCriticalRate, double levelDefense, double levelMagicDefense)
		{
			this.Name = name;
			this.Strength = strength;
			this.Intelligence = intelligence;
			this.Dexterity = dexterity;
			this.StartHP = startHP;
			this.StartAttack = startAttack;
			this.StartMagicAttack = startMagicAttack;
			this.StartAccuracy = startAccuracy;
			this.StartCriticalRate = startCriticalRate;
			this.StartDefense = startDefense;
			this.StartMagicDefense = startMagicDefense;
			this.LevelHP = levelHP;
			this.LevelAttack = levelAttack;
			this.LevelMagicAttack = levelMagicAttack;
			this.LevelAccuracy = levelAccuracy;
			this.LevelCriticalRate = levelCriticalRate;
			this.LevelDefense = levelDefense;
			this.LevelMagicDefense = levelMagicDefense;
		}
	}
}