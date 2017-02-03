using System;
namespace BattleShips
{
	public interface IConsoleWrapper
	{
		void WriteLine(string output);
		string ReadLine();
	}

	public class ConsoleWrapper: IConsoleWrapper
	{
		public void WriteLine(string output)
		{
			Console.WriteLine(output);
		}

		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
