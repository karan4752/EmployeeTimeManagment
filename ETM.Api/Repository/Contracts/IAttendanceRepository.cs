using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Api;
    public interface IAttendanceRepository
    {
        Task<IEnumerable<AttendanceDto>> GetByIdAsync(int id);
    }
