namespace ETM.Api;
public class EmployeeHierarchy
{
    public int RelationshipID { get; set; }
    public int SuperiorEmployeeID { get; set; }
    public int SubordinateEmployeeID { get; set; }

    public Employee SuperiorEmployee { get; set; }
    public Employee SubordinateEmployee { get; set; }
}