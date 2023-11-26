using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Api;
public class LeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; }
    public string Status { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public int EmployeeID { get; set; }
}