using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Api;
public interface IRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();
#nullable enable
    public Task<T?> GetByIdAsync(int Id);
    public Task<T> CreatAsync(T t);
    public Task<T?> UpdateAsync(int id, T t);
    public Task<T?> DeleteAsync(int id);
#nullable disable
}
