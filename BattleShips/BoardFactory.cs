using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
	public interface IBoardFactory
	{
		Dictionary<string, Ship> BuildBoard(List<Ship> ships, int boardSize);
	}

	public class BoardFactory : IBoardFactory
	{
		Random _rnd;
		public BoardFactory()
		{
			_rnd = new Random();
		}

		public Dictionary<string, Ship> BuildBoard(List<Ship> ships, int boardSize = 10)
		{
			var board = new Dictionary<string, Ship>();
			foreach (var ship in ships)
			{
				var placed = false;
				while (!placed)
				{
					List<string> positions = GenerateShipPositions(boardSize, ship.Length);
					if (positions.All(p => !board.ContainsKey(p)))
					{
						positions.ForEach(p => board.Add(p, ship));
						placed = true;
					}
				}
			}

			return board;
		}

		List<string> GenerateShipPositions(int boardSize, int shipLength)
		{
			var positions = new List<string>();
			var isHorizontal = _rnd.Next(0, 99) < 50;
			Position startPosition = GenerateStartPosition(boardSize, shipLength, isHorizontal);

			for (int i = 0; i < shipLength; i++)
			{
				int x = startPosition.X + (isHorizontal ? 0 : i),
				y = startPosition.Y + (isHorizontal ? i : 0);

				positions.Add($"{(char)x}{y}");
			}

			return positions;
		}

		private Position GenerateStartPosition(int boardSize, int shipLength, bool isHorizontal)
		{
			return new Position
			{
				Y = _rnd.Next(1, isHorizontal ? boardSize - shipLength : boardSize),
				X = _rnd.Next(1, isHorizontal ? boardSize : boardSize - shipLength) + 96
			};
		}

		private class Position
		{
			public int X { get; set; }
			public int Y { get; set; }
		}
	}
}
