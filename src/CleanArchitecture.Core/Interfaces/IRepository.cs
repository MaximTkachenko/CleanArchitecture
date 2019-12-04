using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.SharedKernel;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;

        IEnumerable<T> List<T>(ISpecification<T> spec, Page page = null) where T : BaseEntity;
        Task<int> CountAsync<T>(ISpecification<T> spec) where T : BaseEntity;
        Task<T> FirstOrDefaultAsync<T>(ISpecification<T> spec) where T : BaseEntity;
        Task<bool> AnyAsync<T>(ISpecification<T> spec) where T : BaseEntity;
    }
}
