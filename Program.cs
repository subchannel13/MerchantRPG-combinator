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
			foreach(var hero in Library.Heroes)
				combinator.AnalyzeHero(hero, 40, Library.Monsters.Where(x => x.Name == "Ares Prime").First());
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

	}
}