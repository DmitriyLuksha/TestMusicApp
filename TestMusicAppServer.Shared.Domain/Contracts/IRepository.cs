using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestMusicAppServer.Shared.Domain.Contracts
{
    public interface IRepository<T>
        where T: class
    {
        Task<T> GetByIdAsync(int id);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> FindListAsync(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T value);

        Task UpdateAsync(T value);

        Task DeleteAsync(int id);
    }
}
