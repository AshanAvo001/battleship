using BattleshipGameDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGameServices
{
    public interface IGameService
    {
        void InitializeGame();
        string FireShot(Position shot);
    }
}
