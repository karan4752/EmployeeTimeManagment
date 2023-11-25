namespace ETM.Api;
public class TimeSheet
{
    public int TimeSheetID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime WeekStartDate { get; set; }
    public DateTime WeekEndDate { get; set; }
    public decimal TotalHoursWorked { get; set; }

    public Employee Employee { get; set; }
}