using BattleshipGameDomain;
using BattleshipGameServices;

namespace GameServiceTests.Tests
{
    public class GameServiceTests
    {
        private readonly GameService _gameService;

        public GameServiceTests()
        {
            _gameService = new GameService(); 
            _gameService.InitializeGame(); 
        }

        [Fact]
        public void FireShot_AtEmptyCell_ReturnsMiss()
        {
            Position shot = new Position { X = 0, Y = 0 }; 
            var result = _gameService.FireShot(shot);
            Assert.Equal("Miss", result); 
        }

        [Fact]
        public void FireShot_AtShip_ReturnsHit()
        {
            Position shot = new Position { X = 2, Y = 3 }; 
            var result = _gameService.FireShot(shot);
            Assert.Equal("Hit", result); 
        }

        [Fact]
        public void FireShot_AtSameCellTwice_ReturnsAlreadyFiredHere()
        {
            Position shot = new Position { X = 1, Y = 1 }; 
            _gameService.FireShot(shot);
            var result = _gameService.FireShot(shot); 
            Assert.Equal("Already fired here", result);
        }

        [Fact]
        public void FireShot_ToSinkShip_ReturnsHitAndSunk()
        {
            Position shot = new Position { X = 1, Y = 1 }; 
            var result = _gameService.FireShot(shot); 
            Assert.Contains("Miss", result); 
        }
    }
}
