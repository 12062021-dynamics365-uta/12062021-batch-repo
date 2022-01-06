using GamePlayLogic1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Threading.Tasks;

namespace Rps_GameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RpsGameController : Controller //may need to be ControllerBase????
    {
        // if this is static, you COULD access it with RpsGame._gamePlayLogic
        // if it's jsut readonly, you woud have to create an instance of the class
        // first (RpsGame rps = new RpsGame();), then access it with rps._gamePlayLogic
        private readonly IGamePlayLogic _gamePlayLogic;
        private readonly ILogger<RpsGameController> _logger;

        public RpsGameController(IGamePlayLogic gpl, ILogger<RpsGameController> logger)// the controller depends on the GamePlayLogic methods
        {
            this._gamePlayLogic = gpl;
            _logger = logger;
        }

        /// <summary>
        /// This method will take the first and last names of the player and check if that player exists in the 
        /// Db. if not return 'notrfound'
        /// if so, return the player object.
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("loginplayer/{fname}/{lname}")] //    Http://5001/rpsgame/loginplayer/mark/moore
        public async Task<ActionResult<Player>> LoginPlayerAsync(string fname, string lname)
        {
            //call the business (gpl) layer to retrieve the player, if it exists
            //Player p = await this._gamePlayLogic.LoginAsync(fname,lname);
            Task<Player> tsk = this._gamePlayLogic.LoginAsync(fname, lname);// get the Task that is the reference to the thing you are waiting for

            // do something that takes some time and isn't dependent on the Player you are waiting for.

            Player p1 = await tsk;
            if (p1 == null) return NotFound();
            else return Ok(p1);// ok is the 200 (success) response and the P (Player) is returned in the body of the response
        } 

        [HttpPost]
        [Route("RegisterNewPlayer/{fname}/{lname}")]
        public async Task<ActionResult<Player>> RegisterNewPlayerAsync(string fname, string lname)
        {
            // call the business layer to register a player
            Player p = await this._gamePlayLogic.RegisterNewPlayerAsync(fname,lname);
            if (p != null)
            {
                return Created($"http://5001/rpsgame/players/{p.PlayerId}", p);//make sure this URI is correct
            }
            //else return BadRequest("Creating the Player was Unsuccessful");
            else return new UnprocessableEntityResult(); //TODO maybe change this later.

        }
    }
}
