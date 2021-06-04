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
    public class CidadesController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;
        public CidadesController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }
        // GET: api/<CidadesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> Get()
        {
            var result = await _cidadeService.List();

            return Ok(result);
        }

        // GET api/<CidadesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Cidade>>> Get(int id)
        {
            var result = await _cidadeService.GetEntityById(id);

            return Ok(result);
        }

        // POST api/<CidadesController>
        [HttpPost]
        public ActionResult Post([FromBody] Cidade model)
        {
            var result = _cidadeService.Add(model).Status;
            return Ok(result);
        }

        // PUT api/<CidadesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cidade model)
        {
            var result = _cidadeService.Update(model).Status;
            return Ok(result);
        }

        // DELETE api/<CidadesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _cidadeService.Delete(id);
            return Ok();
        }
    }
}
