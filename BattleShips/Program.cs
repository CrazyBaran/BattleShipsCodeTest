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
			var consoleUI = new ConsoleUI(game, new ConsoleWrapper());

			consoleUI.Play();
		}
	}
}
