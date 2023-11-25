namespace ETM.Api;
public class Project
{
    public int ProjectID { get; set; }
    public int ProjectName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }

    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
}