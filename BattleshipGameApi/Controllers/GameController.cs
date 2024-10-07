using BattleshipGameDomain;
using BattleshipGameServices;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipGameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController: ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpPost("fire")]
        public ActionResult<string> FireShot([FromBody] Position position)
        {
            var result = _gameService.FireShot(position);
            return Ok(result);
        }
    }
}
