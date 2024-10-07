using BattleshipGameDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGameServices
{
    public class GameService : IGameService
    {
        private readonly Board _board;
        private readonly List<Ship> _ships;

        public GameService()
        {
            _board = new Board();
            _ships = new List<Ship>
            {
                new Ship("Battleship", _board),
                new Ship("Destroyer 1", _board),
                new Ship("Destroyer 2", _board)
            };
        }

        public void InitializeGame()
        {
            Random random = new Random();
            foreach (var ship in _ships)
            {
                bool placed = false;
                while (!placed)
                {
                    int startX = random.Next(0, Board.Size);
                    int startY = random.Next(0, Board.Size);
                    bool horizontal = random.Next(0, 2) == 0;

                    // Can be set through the param or setup.
                    // Set ship lengths explicitly before placement
                    int length = (ship.Name == "Battleship" ? 5 : 4);
                    if (CanPlaceShip(length, startX, startY, horizontal))
                    {
                        PlaceShip(ship, startX, startY, horizontal, length);
                        placed = true;
                    }
                }
            }
        }

        private bool CanPlaceShip(int length, int startX, int startY, bool horizontal)
        {
            int endX = startX + (horizontal ? length - 1 : 0);
            int endY = startY + (horizontal ? 0 : length - 1);

            if (endX >= Board.Size || endY >= Board.Size) return false;

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    if (_board.Cells[x, y].HasShip) return false;
                }
            }
            return true;
        }

        private void PlaceShip(Ship ship, int startX, int startY, bool horizontal, int length)
        {
            for (int i = 0; i < length; i++)
            {
                int x = startX + (horizontal ? i : 0);
                int y = startY + (horizontal ? 0 : i);

                _board.Cells[x, y].HasShip = true;
                ship.Positions.Add(new Position { X = x, Y = y });
            }
        }

        public string FireShot(Position shot)
        {
            if (shot.X < 0 || shot.X >= Board.Size || shot.Y < 0 || shot.Y >= Board.Size)
                return "Out of bounds";

            Cell targetCell = _board.Cells[shot.X, shot.Y];
            if (targetCell.IsHit)
                return "Already fired here";

            targetCell.IsHit = true;

            foreach (var ship in _ships)
            {
                if (ship.Positions.Any(p => p.X == shot.X && p.Y == shot.Y))
                {
                    if (ship.IsSunk)
                        return $"Hit and sunk {ship.Name}";

                    return "Hit";
                }
            }

            return "Miss";
        }
    }
}
