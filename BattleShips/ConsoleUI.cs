using System;
namespace BattleShips
{
	public interface IConsoleUI
	{
		void Play();
	}

	public class ConsoleUI : IConsoleUI
	{
		readonly IGame _game;
		readonly IConsoleWrapper _consoleWrapper;

		public ConsoleUI(IGame game, IConsoleWrapper consoleWrapper)
		{
			_consoleWrapper = consoleWrapper;
			_game = game;
		}

		public void Play()
		{
			var lastResult = string.Empty;
			while (lastResult != "end")
			{
				lastResult = _game.Shoot(_consoleWrapper.ReadLine());
				_consoleWrapper.WriteLine($">>{lastResult}");
			}
		}
	}
}
