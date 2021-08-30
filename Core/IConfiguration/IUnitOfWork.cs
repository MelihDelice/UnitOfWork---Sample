using System;
using System.Threading.Tasks;
using PocketBook.Core.IRepositories;

namespace PocketBook.Core.IConfiguration
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> CompleteAsync();

    }
}