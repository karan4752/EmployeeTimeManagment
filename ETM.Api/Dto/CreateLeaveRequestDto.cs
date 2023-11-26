using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Api;

    public class CreateLeaveRequestDto
    {
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; }
    public string Status { get; set; }
    public int EmployeeID { get; set; }
}
