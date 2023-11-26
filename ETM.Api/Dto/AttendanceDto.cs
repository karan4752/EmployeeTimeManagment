using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Api
{
    public class AttendanceDto
    {
        public DateTime Date { get; set; }
        public TimeSpan? ClockInTime { get; set; }
        public TimeSpan? ClockOutTime { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}