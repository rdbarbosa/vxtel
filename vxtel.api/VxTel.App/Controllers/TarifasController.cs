using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Application.Interfaces;
using VxTel.Entities.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VxTel.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifasController : ControllerBase
    {
        private readonly ITarifaService _tarifaService;
        public TarifasController(ITarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }
        // GET: api/<TarifasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarifa>>> Get()
        {
            var result = await _tarifaService.List();

            return Ok(result);
        }

        // GET api/<TarifasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Tarifa>>> Get(int id)
        {
            var result = await _tarifaService.GetEntityById(id);

            return Ok(result);
        }

        // POST api/<TarifasController>
        [HttpPost]
        public ActionResult Post([FromBody] Tarifa model)
        {
            var result = _tarifaService.Add(model).Status;
            return Ok(result);
        }

        // PUT api/<TarifasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Tarifa model)
        {
            var result = _tarifaService.Update(model).Status;
            return Ok(result);
        }

        // DELETE api/<TarifasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _tarifaService.Delete(id);
            return Ok();
        }
    }
}
