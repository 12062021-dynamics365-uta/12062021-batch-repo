using GamePlayLogic1;
using Microsoft.AspNetCore.Mvc;
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
        public RpsGameController(IGamePlayLogic gpl)
        {
            this._gamePlayLogic = gpl;
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
            Player p = await this._gamePlayLogic.LoginAsync(fname,lname);
            if (p == null) return NotFound();
            else return Ok(p);// ok is the 200 (success) response and the P (Player) is returned in the body of the response
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
