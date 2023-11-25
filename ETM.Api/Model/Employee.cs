namespace ETM.Api;
public class Employee
{
    public int EmployeeID { get; set; }
    public int? AppUserID { get; set; }
    public int? DepartmentID { get; set; }
    public int? ManagerID { get; set; }

    public AppUser AppUser { get; set; }
    public Department Department { get; set; }
    public Employee Manager { get; set; }

    public ICollection<Attendance> Attendances { get; set; }
    public ICollection<LeaveRequest> LeaveRequests { get; set; }
    public ICollection<TimeSheet> TimeSheets { get; set; }
    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    public ICollection<EmployeeHierarchy> SubordinateRelations { get; set; }
    public ICollection<EmployeeHierarchy> SuperiorRelations { get; set; }
}