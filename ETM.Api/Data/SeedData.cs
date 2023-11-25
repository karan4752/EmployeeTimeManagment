using ETM.Api;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider){
        using (var context= new EtmDataContext(serviceProvider.GetRequiredService<DbContextOptions<EtmDataContext>>()))
        {
            //CHeck if database already exists
            context.Database.EnsureCreated();

            //Seed data if the database is empty
            if (!context.AppUsers.Any())
            {
                SeedAppUsers(context);
                SeedDepartments(context);
                SeedEmployees(context);
                SeedAttendance(context);
                SeedLeaveRequests(context);
                SeedTimeSheets(context);
                SeedProjects(context);
                SeedEmployeeProjects(context);
                SeedEmployeeHierarchy(context);
            }
        }
    }

    private static void SeedEmployeeHierarchy(EtmDataContext context)
    {
        var employeeHierarchy = new List<EmployeeHierarchy>
    {
        new EmployeeHierarchy { SuperiorEmployeeID = 2, SubordinateEmployeeID = 1 }, // Jane Smith is the superior of John Doe
        new EmployeeHierarchy { SuperiorEmployeeID = 3, SubordinateEmployeeID = 1 }  // Admin User is the superior of John Doe
    };

        context.EmployeeHierarchies.AddRange(employeeHierarchy);
        context.SaveChanges();
    }

    private static void SeedEmployeeProjects(EtmDataContext context)
    {
        var employeeProjects = new List<EmployeeProject>
    {
        new EmployeeProject { EmployeeID = 1, ProjectID = 1 },
        new EmployeeProject { EmployeeID = 2, ProjectID = 2 },
        new EmployeeProject { EmployeeID = 1, ProjectID = 2 }
    };

        context.EmployeeProjects.AddRange(employeeProjects);
        context.SaveChanges();
    }

    private static void SeedProjects(EtmDataContext context)
    {
        var projects = new List<Project>
    {
        new Project { ProjectName = "Project A", StartDate = DateTime.Now.Date, EndDate = DateTime.Now.Date.AddDays(30), Description = "Description for Project A" },
        new Project { ProjectName = "Project B", StartDate = DateTime.Now.Date.AddDays(10), EndDate = DateTime.Now.Date.AddDays(40), Description = "Description for Project B" }
    };

        context.Projects.AddRange(projects);
        context.SaveChanges();
    }

    private static void SeedTimeSheets(EtmDataContext context)
    {
        var timeSheets = new List<TimeSheet>
    {
        new TimeSheet { EmployeeID = 1, WeekStartDate = DateTime.Now.Date.AddDays(-7), WeekEndDate = DateTime.Now.Date, TotalHoursWorked = 40 },
        new TimeSheet { EmployeeID = 2, WeekStartDate = DateTime.Now.Date.AddDays(-7), WeekEndDate = DateTime.Now.Date, TotalHoursWorked = 35 }
    };

        context.TimeSheets.AddRange(timeSheets);
        context.SaveChanges();
    }

    private static void SeedLeaveRequests(EtmDataContext context)
    {
        var leaveRequests = new List<LeaveRequest>
    {
        new LeaveRequest { EmployeeID = 1, StartDate = DateTime.Now.Date, EndDate = DateTime.Now.Date.AddDays(2), LeaveType = "Vacation", Status = "Pending" },
        new LeaveRequest { EmployeeID = 2, StartDate = DateTime.Now.Date.AddDays(3), EndDate = DateTime.Now.Date.AddDays(5), LeaveType = "Sick Leave", Status = "Approved" }
    };

        context.LeaveRequests.AddRange(leaveRequests);
        context.SaveChanges();
    }

    private static void SeedAttendance(EtmDataContext context)
    {
        var attendance = new List<Attendance>
        {
            new Attendance { EmployeeID = 1, Date = DateTime.Now.Date, ClockInTime = new TimeSpan(8, 0, 0), ClockOutTime = new TimeSpan(17, 0, 0), Status = "Present" },
            new Attendance { EmployeeID = 2, Date = DateTime.Now.Date, ClockInTime = new TimeSpan(9, 0, 0), ClockOutTime = new TimeSpan(18, 0, 0), Status = "Present" }
        };

        context.Attendances.AddRange(attendance);
        context.SaveChanges();
    }

    private static void SeedEmployees(EtmDataContext context)
    {
        var employees = new List<Employee>
        {
            new Employee { AppUserID = 1, DepartmentID = 2 }, // John Doe in Engineering department
            new Employee { AppUserID = 2, DepartmentID = 1 }, // Jane Smith in HR department
            new Employee { AppUserID = 3, DepartmentID = 3 }  // Admin User in Marketing department
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();
    }

    private static void SeedDepartments(EtmDataContext context)
    {
        var departments = new List<Department>
        {
            new Department { DepartmentName = "HR" },
            new Department { DepartmentName = "Engineering" },
            new Department { DepartmentName = "Marketing" }
        };

        context.Departments.AddRange(departments);
        context.SaveChanges();
    }

    private static void SeedAppUsers(EtmDataContext context)
    {
        var appUsers = new List<AppUser>
        {
            new AppUser { Username = "john_doe", PasswordHash = "hashed_password", FirstName = "John", LastName = "Doe", Email = "john@example.com", Role = "Employee" },
            new AppUser { Username = "jane_smith", PasswordHash = "hashed_password", FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Role = "Manager" },
            new AppUser { Username = "admin", PasswordHash = "hashed_password", FirstName = "Admin", LastName = "User", Email = "admin@example.com", Role = "Admin" }
        };
        context.AppUsers.AddRange(appUsers);
        context.SaveChanges();
    }
}