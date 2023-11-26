using Microsoft.EntityFrameworkCore;

namespace ETM.Api;
public class AttendanceRepository : IAttendanceRepository
{
    private EtmDataContext _EtmDataContext { get; set; }
    public AttendanceRepository(EtmDataContext etmDataContext)
    {
        _EtmDataContext = etmDataContext;

    }

    public async Task<IEnumerable<AttendanceDto>> GetByIdAsync(int id)
    {
        // var attendances = await (_EtmDataContext.Attendances.
        // Include(a => a.Employee).
        // ThenInclude(e => e.AppUser).
        // Where(e => e.EmployeeID == id)).ToListAsync();
        var attendances = await (from f in _EtmDataContext.Attendances
                                 join e in _EtmDataContext.Employees
                                 on f.EmployeeID equals e.EmployeeID
                                 join a in _EtmDataContext.AppUsers
                                 on e.EmployeeID equals a.UserID
                                 where e.EmployeeID == id
                                 select new AttendanceDto
                                 {
                                     Date = f.Date,
                                     ClockInTime = f.ClockInTime,
                                     ClockOutTime = f.ClockOutTime,
                                     Status = f.Status,
                                     Username = a.Username,
                                     FirstName = a.FirstName,
                                     LastName = a.LastName,
                                     Email = a.Email,
                                     Role = a.Role
                                 }).ToListAsync();

        return attendances;
    }

}