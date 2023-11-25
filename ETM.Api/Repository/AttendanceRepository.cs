using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ETM.Api.Repository
{
    public class AttendanceRepository : IRepository<Attendance>
    {
        private EtmDataContext _EtmDataContext { get; set; }
        public AttendanceRepository(EtmDataContext etmDataContext)
        {
            _EtmDataContext = etmDataContext;

        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _EtmDataContext.Attendances.Include(a => a.EmployeeID).ToListAsync();
        }

        public Task<Attendance?> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> CreatAsync(Attendance t)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance?> UpdateAsync(int id, Attendance t)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}