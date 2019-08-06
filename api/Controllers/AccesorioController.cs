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
    public class AccesorioController : Controller
    {
        private readonly IAccesoriosService _accesoriosService;

        public AccesorioController(IAccesoriosService accesoriosService)
        {
            _accesoriosService = accesoriosService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _accesoriosService.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                 _accesoriosService.Get(id)
                 );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Accesorios model)
        {
            return Ok(
                 _accesoriosService.Add(model)
                 );

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Accesorios model)
        {
            return Ok(
                 _accesoriosService.Add(model)
                 );

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                 _accesoriosService.Delete(id)
                 );
        }
    }
}
