using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGameDomain
{
    public class Ship
    {
        public string Name { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();
        private Board _board; 

        public Ship(string name, Board board)
        {
            Name = name;
            _board = board;
            Positions = new List<Position>();
        }

        public bool IsSunk
        {
            get
            {
                return Positions.All(position => _board.Cells[position.X, position.Y].IsHit);
            }
        }
    }
}
