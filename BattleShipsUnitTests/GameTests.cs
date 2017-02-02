using BattleShips;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace BattleShipsUnitTests
{
	[TestFixture]
	public class GameTests
	{
		[Test]
		public void WhenShootingAtEmptyItsAMiss()
		{
			var board = new Dictionary<string, Ship>();
			var subject = new Game(board);

			var result = subject.Shoot("a1");

			result.ShouldMatch("miss");
		}

		[Test]
		public void WhenShootingAtShipItsAHit()
		{
			var ship = new Ship { Length = 3 };
			var board = new Dictionary<string, Ship>()
			{
				{"a1", ship},
				{"a2", ship}
			};
			var subject = new Game(board);

			var result = subject.Shoot("a1");

			result.ShouldMatch("hit");
		}

		[Test]
		public void WhenShootingAtSameShipLocationSecondTimeItsAMiss()
		{
			var board = new Dictionary<string, Ship>()
			{
				{"a1", new Ship {Length = 3}}
			};
			var subject = new Game(board);

			subject.Shoot("a1");
			var result = subject.Shoot("a1");

			result.ShouldMatch("miss");
		}

		[Test]
		public void WhenShootingAtLastShipPointItsASink()
		{
			var board = new Dictionary<string, Ship>()
			{
				{"a1", new Ship { Length = 1}},
				{"a2", new Ship { Length = 1}}
			};
			var subject = new Game(board);

			var result = subject.Shoot("a1");

			result.ShouldMatch("sink");
		}

		[Test]
		public void WhenSinkingLastShipTheGameEnds()
		{
			var board = new Dictionary<string, Ship>()
			{
				{"a1", new Ship { Length = 1}}
			};
			var subject = new Game(board);

			var result = subject.Shoot("a1");

			result.ShouldMatch("end");
		}
	}
}
