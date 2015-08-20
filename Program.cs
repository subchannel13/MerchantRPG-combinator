using System;
using System.Collections.Generic;
using System.Linq;
using Merchant_RPG_build.MetaData;
using Merchant_RPG_build.Processing;

namespace Merchant_RPG_build
{
	class Program
	{
		public static void Main(string[] args)
		{
			var buildStyles = new BuildPurpose[4];
			for (int i = 0; i < 4; i++)
				buildStyles[i] = (BuildPurpose)i;
			var buildNames = new string[] {
				"Min HP loss",
				"Min turns",
				"Max defense",
				"Max effective HP"
			};
			var buildScore = new string[] {
				"HP lost",
				"turns",
				"monster damage",
				"HP"
			};
			
			var monster = Library.Monsters.First(x => x.Name == "Ares Prime");

			var combinator = new Combinator();
			for (int i = 0; i < 4; i++)
			{
				var buildStyle = (BuildPurpose)i;
				Console.WriteLine(buildNames[i] + ":");

				foreach (var hero in Library.Heroes)
				{
					Console.WriteLine("  " + hero.Name + ":");
					foreach (var build in combinator.AnalyzeHero(hero, 40, monster, buildStyle))
					{
						Console.Write("    ");
						for (int slot = 0; slot < build.Items.Length; slot++)
						{
							Console.Write(build.Items[slot].Name + ", ");
						}
						Console.WriteLine();
						Console.WriteLine("    score: {0} {1}", build.Score.ToString("0.##"), buildScore[i]);
					}
				}

				Console.WriteLine();
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

	}
}