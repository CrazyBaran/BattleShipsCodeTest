using System;
using System.Collections.Generic;

namespace BattleShips
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var board = new BoardFactory().BuildBoard(new List<Ship> { new Ship { Length = 5 }, new Ship { Length = 4 }, new Ship { Length = 4 } });
			var game = new Game(board);

			var lastResult = string.Empty;
			while (lastResult != "end")
			{
				lastResult = game.Shoot(Console.ReadLine());
				Console.WriteLine($">>{lastResult}");
			}
		}
	}
}
