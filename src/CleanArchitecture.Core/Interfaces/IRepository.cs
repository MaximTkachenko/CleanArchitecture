using System.Collections.Generic;
using CleanArchitecture.SharedKernel;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        IEnumerable<T> List<T>(ISpecification<T> spec, Page page = null) where T : BaseEntity;
        int Count<T>(ISpecification<T> spec) where T : BaseEntity;
        T FirstOrDefault<T>(ISpecification<T> spec) where T : BaseEntity;
        bool Any<T>(ISpecification<T> spec) where T : BaseEntity;
    }
}
