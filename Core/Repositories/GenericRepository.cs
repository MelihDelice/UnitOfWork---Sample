using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IRepositories;
using PocketBook.Data;
using PocketBook.Models;

namespace PocketBook.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel,new()
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await dbSet.FindAsync(id);

            }
            catch (System.Exception ex)
            {
                //TODO
                throw;
            }
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (System.Exception ex)
            {
                //TODO
                throw;
            }

        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var dataToDalate = await dbSet.FindAsync(id);
                if (dataToDalate != null)
                {
                    //dataToDalate.RemovedDate = DateTime.Now;
                    //dataToDalate.UpdatedDate = DateTime.Now;
                    //dataToDalate.IsActiveStatus = 99;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                //TODO
                // _logger.LogError(ex, "{Repo} Delete method error!", typeof(T));
                throw;
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                dbSet.Update(entity);
                return true;
            }
            catch (System.Exception ex)
            {
                //TODO
                throw;
            }

        }
    }

}