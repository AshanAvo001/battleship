using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGameDomain
{
    public class Board
    {
        public const int Size = 10; // 10x10 board
        public Cell[,] Cells { get; } = new Cell[Size, Size];

        public Board()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }
    }
}
