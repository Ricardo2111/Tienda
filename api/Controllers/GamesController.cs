using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _gamesService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                 _gamesService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Games model)
        {
            return Ok(
                 _gamesService.Add(model)
                 );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Games model)
        {
            return Ok(
                 _gamesService.Update(model)
                 );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                 _gamesService.Delete(id)
                 );
        }
    }
}
