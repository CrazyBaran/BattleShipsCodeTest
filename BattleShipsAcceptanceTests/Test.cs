using NUnit.Framework;
using System;
using System.Collections.Generic;
using BattleShips;
using NSubstitute;

namespace BattleShipsAcceptanceTests
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void SimpleGame()
		{
			var board = new BoardFactory().BuildBoard(new List<Ship> { new Ship { Length = 5 }, new Ship { Length = 4 }, new Ship { Length = 4 } });
			var game = new Game(board);
			var consoleWrapper = Substitute.For<IConsoleWrapper>();
			var consoleUI = new ConsoleUI(game, consoleWrapper);

			int y = 97, x = 0, count = 0;
			consoleWrapper.ReadLine().Returns(c =>
			{
				if (count > 100)
					throw new Exception("game haven't finished");
				x++;
				if (x == 11)
				{
					x = 1;
					y++;
				}
				return $"{(char)y}{x}";
			});

			consoleUI.Play();

			consoleWrapper.Received().WriteLine(">>miss");
			consoleWrapper.Received().WriteLine(">>hit");
			consoleWrapper.Received(2).WriteLine(">>sink");
			consoleWrapper.Received(1).WriteLine(">>end");
		}
	}
}
