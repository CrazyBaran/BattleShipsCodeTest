using System;
using System.Collections.Generic;

namespace BattleShips
{
	public interface IGame
	{
		string Shoot(string point);
	}

	public class Game : IGame
	{
		readonly Dictionary<string, Ship> board;

		public Game(Dictionary<string, Ship> board)
		{
			this.board = board;
		}

		public string Shoot(string point)
		{
			if (!board.ContainsKey(point))
				return "miss";

			var ship = board[point];
			board.Remove(point);

			if (board.Count == 0)
				return "end";

			ship.Length--;
			return ship.Length == 0 ? "sink" : "hit";
		}
	}

}
