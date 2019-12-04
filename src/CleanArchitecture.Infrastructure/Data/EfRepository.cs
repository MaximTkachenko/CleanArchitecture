using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.SharedKernel;

namespace CleanArchitecture.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        //SaveChanges should be called outside of repository
        //in case of web application it's called in separate middleware after main pipe invocation
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> List<T>(ISpecification<T> spec, Page page = null) where T : BaseEntity
        {
            var query = BuildQuery(spec);

            if (page != null)
            {
                query = query.Skip(page.Skip).Take(page.Take);
            }

            return query.AsEnumerable();
        }

        public int Count<T>(ISpecification<T> spec) where T : BaseEntity
        {
            return BuildQuery(spec).Count();
        }

        public T FirstOrDefault<T>(ISpecification<T> spec) where T : BaseEntity
        {
            return BuildQuery(spec).FirstOrDefault();
        }

        public bool Any<T>(ISpecification<T> spec) where T : BaseEntity
        {
            return BuildQuery(spec).Any();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> BuildQuery<T>(ISpecification<T> spec) where T : BaseEntity
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return spec.Criteria == null
                ? secondaryResult
                : secondaryResult.Where(spec.Criteria);
        }
    }
}
