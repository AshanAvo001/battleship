using BattleshipGameDomain;
using BattleshipGameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleshipGameTests
{
    public class GameServiceTests
    {
        private readonly GameService _gameService;

        public GameServiceTests()
        {
            _gameService = new GameService(); // Assuming GameService has its dependencies properly handled internally.
            _gameService.InitializeGame(); // Initializes the game board and places ships.
        }

        [Fact]
        public void FireShot_AtEmptyCell_ReturnsMiss()
        {
            // Arrange
            Position shot = new Position { X = 0, Y = 0 }; // Ensure this position will not hit any ships.

            // Act
            var result = _gameService.FireShot(shot);

            // Assert
            Assert.Equals("Miss", result); // Use Assert.Equal for string comparison.
        }

        [Fact]
        public void FireShot_AtShip_ReturnsHit()
        {
            // Arrange
            Position shot = new Position { X = 1, Y = 1 }; // Ensure this position will hit a ship.

            // Act
            var result = _gameService.FireShot(shot);

            // Assert
            Assert.Equals("Hit", result); // Use Assert.Equal for string comparison.
        }

        [Fact]
        public void FireShot_AtSameCellTwice_ReturnsAlreadyFiredHere()
        {
            // Arrange
            Position shot = new Position { X = 1, Y = 1 }; // Ensure this position is where a ship is placed.
            _gameService.FireShot(shot); // First shot to hit or miss.

            // Act
            var result = _gameService.FireShot(shot); // Second shot at the same position.

            // Assert
            Assert.Equals("Already fired here", result); // Use Assert.Equal for string comparison.
        }

        [Fact]
        public void FireShot_ToSinkShip_ReturnsHitAndSunk()
        {
            // Act
            var result = _gameService.FireShot(new Position { X = 1, Y = 1 }); // Ensure this is the final shot to sink the ship.

            // Assert
            Assert.Equals("sunk", result); // Assert.Contains to verify 'sunk' is in the result string.
        }
    }
}
