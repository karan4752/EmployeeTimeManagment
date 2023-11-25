using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETM.Api;

public class DepartmentRepository : IRepository<Department>
{
    private EtmDataContext _db { get; set; }
    public DepartmentRepository(EtmDataContext db)
    {
        _db = db;

    }
    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _db.Departments.ToListAsync();
    }
    public async Task<Department?> GetByIdAsync(int id)
    {
        var dept = await _db.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
        if (dept is null) return null;
        return dept;
    }

    public async Task<Department> CreatAsync(Department t)
    {
        await _db.Departments.AddAsync(t);
        await _db.SaveChangesAsync();
        return t;
    }

    public async Task<Department?> UpdateAsync(int id, Department t)
    {
        var oldDept = await GetByIdAsync(id);
        if (oldDept is null) return null;
        oldDept.DepartmentID = id;
        oldDept.DepartmentName = t.DepartmentName;
        _db.Departments.Update(oldDept);
        await _db.SaveChangesAsync();
        return await GetByIdAsync(id);
    }

    public async Task<Department?> DeleteAsync(int id)
    {
        var deleteDept = await GetByIdAsync(id);
        if (deleteDept is null) return null;
        _db.Departments.Remove(deleteDept);
        await _db.SaveChangesAsync();
        return deleteDept;
    }


}
