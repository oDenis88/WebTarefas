using Microsoft.AspNetCore.Mvc;
using WebTarefas.Domain.Models;
using WebTarefas.Services.TarefaServices;

namespace WebTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _service;

        public TarefaController(ITarefaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Tarefa tarefa)
        {
            await _service.AddAsync(tarefa);
            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
                return BadRequest();

            await _service.UpdateAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
