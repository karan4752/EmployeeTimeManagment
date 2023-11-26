using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        public ILeaveRequestRepository _leaveRequestRepository { get; set; }
        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLeavesAsync([FromRoute] int id)
        {
            var leaveRequests = await _leaveRequestRepository.GetByIdAsync(id);
            if (leaveRequests is null) return NotFound();
            return Ok(leaveRequests);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            if (createLeaveRequestDto is null) return BadRequest();
            var newLeaveRequest = await _leaveRequestRepository.CreateAsync(createLeaveRequestDto);
            if (newLeaveRequest is null) throw new Exception("LeaveRequest is not create.");
            return Ok(newLeaveRequest);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            if (updateLeaveRequestDto is null) return BadRequest();
            var updateLeaveRequestDtoNew = await _leaveRequestRepository.UpdateAsync(id, updateLeaveRequestDto);
            if (updateLeaveRequestDtoNew is null) throw new Exception("LeaveRequest is not updated.");
            return Ok(updateLeaveRequestDtoNew);
        }
    }
}