using Microsoft.AspNetCore.Mvc;
using RebarProject.Models;
using RebarProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RebarProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShakesController : ControllerBase
    {   private readonly IShakeService shakeService;

        public ShakesController(IShakeService shakeService)
        {
            this.shakeService = shakeService;  
        }
        // GET: api/<SgakesController>
        [HttpGet]
        public ActionResult<List<Shake>> Get()
        {
            return shakeService.Get();
        }

        // GET api/<SgakesController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(Guid id)
        {
           var shake = shakeService.Get(id);
            if(shake == null) 
            {
                return NotFound($"Shake with Id={id}not found");
            }
            return shake;
        }

        // POST api/<SgakesController>
        [HttpPost]
        public ActionResult<Shake> Post([FromBody] Shake shake)
        {
            shakeService.Create(shake);
            return CreatedAtAction(nameof(Get), new { id = shake.Id }, shake);
        }

        // PUT api/<SgakesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Shake shake)
        {
            var existingShake= shakeService.Get(id);
            if(existingShake == null)
            {
                return NotFound($"Shake with Id={id}not found");
            }
            shakeService.Update(id, existingShake);
            return NoContent();
        }

        // DELETE api/<SgakesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var shake = shakeService.Get(id);
            if (shake == null)
            {
                return NotFound($"Shake with Id={id}not found");
            }
            shakeService.Remove(shake.Id);
            return Ok($"Shake with id = {id} deleted");
        }
    }
}
