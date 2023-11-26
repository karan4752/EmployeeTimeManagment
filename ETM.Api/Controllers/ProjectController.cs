using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private IRepository<Project> _repository { get; set; }
        public ProjectController(IRepository<Project> repository)
        {
            _repository = repository;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _repository.GetAllAsync();
            if (projects is null) return NoContent();
            return Ok(projects);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var projects = await _repository.GetByIdAsync(id);
            if (projects is null) return NoContent();
            return Ok(projects);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            if (project is null) return BadRequest();
            var addedproject = await _repository.CreatAsync(project);
            return Ok(addedproject);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Project project)
        {
            if (project is null) return BadRequest();
            var updatedproject = await _repository.UpdateAsync(id, project);
            return Ok(updatedproject);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedproject = await _repository.DeleteAsync(id);
            return Ok(deletedproject);
        }
    }
}