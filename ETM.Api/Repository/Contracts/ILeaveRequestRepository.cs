using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Api
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequestDto>> GetByIdAsync(int id);
        Task<CreateLeaveRequestDto> CreateAsync(CreateLeaveRequestDto createLeaveRequestDto);
        Task<UpdateLeaveRequestDto> UpdateAsync(int id, UpdateLeaveRequestDto updateLeaveRequestDto);
    }
}