using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChildrensGame.Api.Models;

namespace ChildrensGame.Api.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private Random rand;

        public GamesController()
        {
            rand = new Random();
        }

        // POST: api/games
        [Produces("application/json")]
        [HttpPost]
        public IActionResult GenerateGameManifest()
        {
            var childrenCount = rand.Next(1, 100);
            var eliminateEach = rand.Next(1, childrenCount);
            return new OkObjectResult(new GameManifest()
            {
                Id = DateTime.UtcNow.Ticks,
                ChildrenCount = childrenCount,
                EliminateEach = eliminateEach
            });
        }

        // POST api/games/{id}/result
        [Consumes("application/json")]
        [HttpPost("{id}/result")]
        public IActionResult SaveResult(long id, [FromBody] GameResult result)
        {
            if (id != result.Id)
            {
                return new BadRequestResult();
            }
            return new OkResult();
        }
    }
}
