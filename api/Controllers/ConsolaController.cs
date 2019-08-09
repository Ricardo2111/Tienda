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
    public class ConsolaController : Controller
    {
        private readonly IConsolaService _consolaService;

        public ConsolaController(IConsolaService consolaService)
        {
            _consolaService = consolaService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _consolaService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                 _consolaService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Consola model)
        {
            return Ok(
                 _consolaService.Add(model)
                 );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Consola model)
        {
            return Ok(
                 _consolaService.Update(model)
                 );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                 _consolaService.Delete(id)
                 );
        }
    }
}
