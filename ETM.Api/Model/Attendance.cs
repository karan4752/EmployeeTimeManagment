namespace ETM.Api;
public class Attendance
{
    public int AttendanceID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan? ClockInTime { get; set; }
    public TimeSpan? ClockOutTime { get; set; }
    public string Status { get; set; }

    public Employee Employee { get; set; }
}