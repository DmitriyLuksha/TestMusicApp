using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestMusicAppServer.Shared.Domain.Contracts;

namespace TestMusicAppServer.Shared.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T: class
    {
        protected BaseRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        protected DbContext Context { get; }

        protected DbSet<T> Set { get; }
        
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Set.FindAsync(id);
        }

        public virtual async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate)
        {
            var query = Set.Where(predicate);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<List<T>> FindListAsync(Expression<Func<T, bool>> predicate)
        {
            var query = Set.Where(predicate);
            return await query.ToListAsync();
        }

        public virtual async Task CreateAsync(T value)
        {
            await Set.AddAsync(value);
            await Context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T value)
        {
            Set.Update(value);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var value = await Set.FindAsync(id);

            if (value != null)
            {
                Set.Remove(value);
            }

            await Context.SaveChangesAsync();
        }
    }
}
