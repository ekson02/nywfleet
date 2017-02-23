using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NywFleet.Data.Contracts {
    public interface IRepository<T> where T : class {
        IQueryable<T> Query();
        IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeExpressions);
        IQueryable<T> GetAllWithInclude(params string[] includeExpressions);

        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        long GenerateId(string sequenceName);
    }
}
