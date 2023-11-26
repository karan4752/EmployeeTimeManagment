using Microsoft.AspNetCore.Mvc;

namespace ETM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private IAttendanceRepository _Repository { get; }
        public AttendanceController(IAttendanceRepository repository)
        {
            _Repository = repository;

        }
        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int employeeId)
        {
            var attendances = await _Repository.GetByIdAsync(employeeId);
            if (attendances is null) return NoContent();
            return Ok(attendances);
        }
    }
}