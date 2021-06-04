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
    public class PlanosController : ControllerBase
    {
        private readonly IPlanoService _planoService;
        public PlanosController(IPlanoService planoService)
        {
            _planoService = planoService;
        }
        // GET: api/<PlanosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plano>>> Get()
        {
            var result = await _planoService.List();

            return Ok(result);
        }

        // GET api/<PlanosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Plano>>> Get(int id)
        {
            var result = await _planoService.GetEntityById(id);

            return Ok(result);
        }

        // POST api/<PlanosController>
        [HttpPost]
        public ActionResult Post([FromBody] Plano model)
        {
            var result = _planoService.Add(model).Status;
            return Ok(result);
        }

        // PUT api/<PlanosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Plano model)
        {
            var result = _planoService.Update(model).Status;
            return Ok(result);
        }

        // DELETE api/<PlanosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _planoService.Delete(id);
            return Ok();
        }
    }
}
