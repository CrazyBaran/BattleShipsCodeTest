using System;
using BattleShips;
using NSubstitute;
using NUnit.Framework;

namespace BattleShipsUnitTests
{
	[TestFixture]
	public class ConsoleUITests
	{
		[Test]
		public void WhenPlayingTheGameItWillFinishWhenFinished()
		{
			var game = Substitute.For<IGame>();
			var console = Substitute.For<IConsoleWrapper>();

			game.Shoot(null).ReturnsForAnyArgs(x => "end", x => { throw new Exception("Shouldn't happen"); });

			var subject = new ConsoleUI(game, console);

			subject.Play();
		}

		[Test]
		public void WhenPlayingTheGameItWillPassConsoleInputToGameAndContinueUntilEnd()
		{
			var game = Substitute.For<IGame>();
			var console = Substitute.For<IConsoleWrapper>();

			console.ReadLine().Returns(x => "a1");
			game.Shoot(null).ReturnsForAnyArgs(x=> "miss", x=> "hit", x => "end", x => { throw new Exception("Shouldn't happen"); });

			var subject = new ConsoleUI(game, console);

			subject.Play();

			game.Received(3).Shoot("a1");
		}

	}
}
