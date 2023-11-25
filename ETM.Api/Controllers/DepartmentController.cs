using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private IRepository<Department> _repository { get; set; }
        public DepartmentController(IRepository<Department> repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var departments = await _repository.GetAllAsync();
            if (departments is null) return NoContent();
            return Ok(departments);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var department = await _repository.GetByIdAsync(id);
            if (department is null) return NoContent();
            return Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            if (department is null) return BadRequest();
            var addedDepartment = await _repository.CreatAsync(department);
            return Ok(addedDepartment);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Department department)
        {
            if (department is null) return BadRequest();
            var updatedDepartment = await _repository.UpdateAsync(id, department);
            return Ok(updatedDepartment);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedDepartment = await _repository.DeleteAsync(id);
            return Ok(deletedDepartment);
        }
    }
}