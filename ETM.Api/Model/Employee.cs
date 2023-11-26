namespace ETM.Api;
public class Employee
{
    public int EmployeeID { get; set; }
    public int? AppUserID { get; set; }
    public int? DepartmentID { get; set; }
    public int? ManagerID { get; set; }

    public virtual AppUser AppUser { get; set; }
    public virtual Department Department { get; set; }
    public virtual Employee Manager { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; }
    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    public virtual ICollection<TimeSheet> TimeSheets { get; set; }
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    public virtual ICollection<EmployeeHierarchy> SubordinateRelations { get; set; }
    public virtual ICollection<EmployeeHierarchy> SuperiorRelations { get; set; }
}