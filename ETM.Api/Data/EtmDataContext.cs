using Microsoft.EntityFrameworkCore;
namespace ETM.Api;
public class EtmDataContext : DbContext
{
    public EtmDataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeHierarchy> EmployeeHierarchies { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent Api
        //App User
        modelBuilder.Entity<AppUser>().HasKey(u => u.UserID);
        modelBuilder.Entity<AppUser>().Property(u => u.UserID).ValueGeneratedOnAdd();
        modelBuilder.Entity<AppUser>().HasIndex(u => u.UserID).IsUnique();
        modelBuilder.Entity<AppUser>().HasMany(u => u.Employees).WithOne(e => e.AppUser).HasForeignKey(e => e.AppUserID);

        //Department
        modelBuilder.Entity<Department>().HasKey(d => d.DepartmentID);
        modelBuilder.Entity<Department>().Property(d => d.DepartmentID).ValueGeneratedOnAdd();
        modelBuilder.Entity<Department>().HasMany(d => d.Employees).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentID);

        //Employee
        modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeID);
        modelBuilder.Entity<Employee>().Property(e => e.EmployeeID).ValueGeneratedOnAdd();
        modelBuilder.Entity<Employee>().HasMany(e => e.Attendances).WithOne(a => a.Employee).HasForeignKey(a => a.EmployeeID);
        modelBuilder.Entity<Employee>().HasMany(e => e.LeaveRequests).WithOne(lr => lr.Employee).HasForeignKey(lr => lr.EmployeeID);
        modelBuilder.Entity<Employee>().HasMany(e => e.TimeSheets).WithOne(t => t.Employee).HasForeignKey(t => t.EmployeeID);
        modelBuilder.Entity<Employee>().HasMany(e => e.EmployeeProjects).WithOne(ep => ep.Employee).HasForeignKey(ep => ep.EmployeeID);
        modelBuilder.Entity<Employee>().HasMany(e => e.SubordinateRelations).WithOne(er => er.SuperiorEmployee).HasForeignKey(er => er.SuperiorEmployeeID);
        modelBuilder.Entity<Employee>().HasMany(e => e.SuperiorRelations).WithOne(er => er.SubordinateEmployee).HasForeignKey(er => er.SubordinateEmployeeID);

        // Attendance
        modelBuilder.Entity<Attendance>().HasKey(a => a.AttendanceID);
        modelBuilder.Entity<Attendance>().Property(a => a.AttendanceID).ValueGeneratedOnAdd();
        modelBuilder.Entity<Attendance>().HasOne(a => a.Employee).WithMany(e => e.Attendances).HasForeignKey(a => a.EmployeeID);

        // LeaveRequest
        modelBuilder.Entity<LeaveRequest>().HasKey(lr => lr.LeaveRequestID);
        modelBuilder.Entity<LeaveRequest>().Property(lr => lr.LeaveRequestID).ValueGeneratedOnAdd();
        modelBuilder.Entity<LeaveRequest>().HasOne(lr => lr.Employee).WithMany(e => e.LeaveRequests).HasForeignKey(lr => lr.EmployeeID);

        // TimeSheet
        modelBuilder.Entity<TimeSheet>().HasKey(ts => ts.TimeSheetID);
        modelBuilder.Entity<TimeSheet>().Property(ts => ts.TimeSheetID).ValueGeneratedOnAdd();
        modelBuilder.Entity<TimeSheet>().HasOne(ts => ts.Employee).WithMany(e => e.TimeSheets).HasForeignKey(ts => ts.EmployeeID);

        // Project
        modelBuilder.Entity<Project>().HasKey(p => p.ProjectID);
        modelBuilder.Entity<Project>().Property(p => p.ProjectID).ValueGeneratedOnAdd();
        modelBuilder.Entity<Project>().HasMany(p => p.EmployeeProjects).WithOne(ep => ep.Project).HasForeignKey(ep => ep.ProjectID);

        // EmployeeProject
        modelBuilder.Entity<EmployeeProject>().HasKey(ep => new { ep.EmployeeID, ep.ProjectID });
        modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Employee).WithMany(e => e.EmployeeProjects).HasForeignKey(ep => ep.EmployeeID);
        modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Project).WithMany(p => p.EmployeeProjects).HasForeignKey(ep => ep.ProjectID);

        // EmployeeHierarchy
        modelBuilder.Entity<EmployeeHierarchy>().HasKey(eh => eh.RelationshipID);
        modelBuilder.Entity<EmployeeHierarchy>().Property(eh => eh.RelationshipID).ValueGeneratedOnAdd();
        modelBuilder.Entity<EmployeeHierarchy>().HasOne(eh => eh.SuperiorEmployee).WithMany(e => e.SubordinateRelations).HasForeignKey(eh => eh.SuperiorEmployeeID);
        modelBuilder.Entity<EmployeeHierarchy>().HasOne(eh => eh.SubordinateEmployee).WithMany(e => e.SuperiorRelations).HasForeignKey(eh => eh.SubordinateEmployeeID);
        
        
        //base.OnModelCreating(modelBuilder);
    }
}