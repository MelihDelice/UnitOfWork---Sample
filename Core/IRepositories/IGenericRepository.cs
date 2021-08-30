using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PocketBook.Models;

namespace PocketBook.Core.IRepositories
{
    public interface IGenericRepository<T> where T : BaseModel, new()
    {
        #region sync
        // IEnumerable<T> All();
        // T GetById(Guid id);
        // bool Add(T entity);
        // bool Delete(Guid id);
        // bool Update(T entity);
        #endregion



        #region Async
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(T entity);
        #endregion

    }
}