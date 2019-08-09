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
    public class CompraGController : Controller
    {
        private readonly ICompraGService _compraGService;

        public CompraGController(ICompraGService compraGService)
        {
            _compraGService = compraGService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _compraGService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                 _compraGService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Compra_Game model)
        {
            return Ok(
                 _compraGService.Add(model)
                 );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Compra_Game model)
        {
            return Ok(
                 _compraGService.Update(model)
                 );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                 _compraGService.Delete(id)
                 );
        }
    }
}
