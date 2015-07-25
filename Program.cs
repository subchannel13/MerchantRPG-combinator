using System;
using System.Collections.Generic;
using System.Linq;
using Merchant_RPG_build.MetaData;

namespace Merchant_RPG_build
{
	class Program
	{
		public static void Main(string[] args)
		{
			var combinator = new Combinator();
			foreach (var hero in Library.Heroes)
			{
				Console.WriteLine(hero.Name + ":");
				foreach (var build in combinator.AnalyzeHero(hero, 40, Library.Monsters.Where(x => x.Name == "Ares Prime").First()))
				{
					for (int slot = 0; slot < build.Items.Length; slot++)
					{
						Console.Write(build.Items[slot].Name + ", ");
					}
					Console.WriteLine("score: " + build.Score.ToString("0.0"));
				}

				Console.WriteLine();
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

	}
}