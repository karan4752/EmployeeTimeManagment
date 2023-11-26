using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ETM.Api.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        public EtmDataContext _etmDataContext { get; set; }
        public LeaveRequestRepository(EtmDataContext etmDataContext)
        {
            _etmDataContext = etmDataContext;

        }
        public async Task<CreateLeaveRequestDto> CreateAsync(CreateLeaveRequestDto createLeaveRequestDto)
        {
            var leaveRequests = new LeaveRequest
            {
                EmployeeID = createLeaveRequestDto.EmployeeID,
                EndDate = createLeaveRequestDto.EndDate,
                LeaveType = createLeaveRequestDto.LeaveType,
                StartDate = createLeaveRequestDto.StartDate,
                Status = createLeaveRequestDto.Status
            };
            var newLeave = await _etmDataContext.LeaveRequests.AddAsync(leaveRequests);
            var newLeaveRequest = new CreateLeaveRequestDto
            {
                EmployeeID = newLeave.Entity.EmployeeID,
                EndDate = newLeave.Entity.EndDate,
                StartDate = newLeave.Entity.StartDate,
                LeaveType = newLeave.Entity.LeaveType,
                Status = newLeave.Entity.Status,
            };
            return newLeaveRequest;
        }

        public async Task<IEnumerable<LeaveRequestDto>> GetByIdAsync(int id)
        {
            var leaveRequests = await (from l in _etmDataContext.LeaveRequests
                                       join e in _etmDataContext.Employees on l.EmployeeID equals e.EmployeeID
                                       join a in _etmDataContext.AppUsers on e.EmployeeID equals a.UserID
                                       where l.EmployeeID == id
                                       select new LeaveRequestDto
                                       {
                                           FirstName = a.FirstName,
                                           LastName = a.LastName,
                                           Email = a.Email,
                                           EmployeeID = e.EmployeeID,
                                           EndDate = l.EndDate,
                                           StartDate = l.StartDate,
                                           LeaveType = l.LeaveType,
                                           Role = a.Role,
                                           Status = l.Status
                                       }).ToListAsync();

            return leaveRequests;
        }

        public async Task<UpdateLeaveRequestDto> UpdateAsync(int id, UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var leaveRequest = await _etmDataContext.LeaveRequests.FirstOrDefaultAsync(l => l.LeaveRequestID == id);
            leaveRequest.EndDate = updateLeaveRequestDto.EndDate;
            leaveRequest.StartDate = updateLeaveRequestDto.StartDate;
            leaveRequest.Status = updateLeaveRequestDto.Status;
            leaveRequest.EmployeeID = updateLeaveRequestDto.EmployeeID;
            _etmDataContext.LeaveRequests.Update(leaveRequest);
            await _etmDataContext.SaveChangesAsync();
            return updateLeaveRequestDto;
        }
    }
}