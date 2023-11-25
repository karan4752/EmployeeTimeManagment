namespace ETM.Api;
public class LeaveRequest
{
    public int LeaveRequestID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; }
    public string Status { get; set; }

    public Employee Employee { get; set; }

}