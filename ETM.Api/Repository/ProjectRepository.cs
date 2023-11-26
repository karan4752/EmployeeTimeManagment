using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ETM.Api;
public class ProjectRepository : IRepository<Project>
{
    private EtmDataContext _db { get; set; }
    public ProjectRepository(EtmDataContext db)
    {
        _db = db;

    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _db.Projects.ToListAsync();
    }
#nullable enable
    public async Task<Project?> GetByIdAsync(int Id)
    {
        var dept = await _db.Projects.FirstOrDefaultAsync(d => d.ProjectID == Id);
        if (dept is null) return null;
        return dept;
    }

    public async Task<Project> CreatAsync(Project t)
    {
        await _db.Projects.AddAsync(t);
        await _db.SaveChangesAsync();
        return t;
    }

    public async Task<Project?> UpdateAsync(int id, Project project)
    {
        var oldproject = await GetByIdAsync(id);
        if (oldproject is null) return null;
        oldproject.ProjectID = id;
        oldproject.ProjectName = project.ProjectName;
        oldproject.Description = project.Description;
        oldproject.EndDate = project.EndDate;
        oldproject.StartDate = project.StartDate;
        _db.Projects.Update(oldproject);
        await _db.SaveChangesAsync();
        return await GetByIdAsync(id);
    }

    public async Task<Project?> DeleteAsync(int id)
    {
        var delete = await GetByIdAsync(id);
        if (delete is null) return null;
        _db.Projects.Remove(delete);
        await _db.SaveChangesAsync();
        return delete;
    }
#nullable disable
}