using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private IRepository<Attendance> _Repository { get; }
        public AttendanceController(IRepository<Attendance> repository)
        {
            _Repository = repository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var attendances = await _Repository.GetAllAsync();
            if (attendances is null) return NoContent();
            return Ok(attendances);
        }
    }
}