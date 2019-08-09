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
    public class CompraAController : Controller
    {
        private readonly ICompraAService _compraAService;

        public CompraAController(ICompraAService compraAService)
        {
            _compraAService = compraAService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _compraAService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                 _compraAService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Compra_Accesorio model)
        {
            return Ok(
                 _compraAService.Add(model)
                 );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Compra_Accesorio model)
        {
            return Ok(
                 _compraAService.Update(model)
                 );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                 _compraAService.Delete(id)
                 );
        }
    }
}
