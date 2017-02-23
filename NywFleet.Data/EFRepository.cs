using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NywFleet.Data.Contracts;

namespace NywFleet.Data {

    public class EfRepository<T> : IRepository<T> where T : class {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public EfRepository(DbContext dbContext) {
            if (dbContext == null) {
                throw new ArgumentNullException("dbContext");
            }

            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }


        public virtual IQueryable<T> Query() {
            return DbSet;
        }

        public IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeExpressions) {
            return includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(DbContext.Set<T>(), (current, expression) => current.Include(expression));
        }


        public IQueryable<T> GetAllWithInclude(params string[] includeExpressions) {
            return includeExpressions.Aggregate<string, IQueryable<T>>(DbContext.Set<T>(), (current, expression) => current.Include(expression));
        }


        public virtual T GetById(int id) {
            T entity = DbSet.Find(id);
            return entity;
        }

        public virtual Task<T> GetByIdAsync(int id) {
            Task<T> entity = DbSet.FindAsync(id);
            return entity;
        }
        public virtual Task<T> FindAsync(int id) {
            Task<T> entity = DbSet.FindAsync(id);
            return entity;
        }

        public virtual void Add(T entity) {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached) {
                dbEntityEntry.State = EntityState.Added;
            } else {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity) {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached) {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }


        public virtual void Delete(int id) {
            var entity = GetById(id);
            if (entity != null)
                Delete(entity);
        }

        public virtual void Delete(T entity) {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted) {
                dbEntityEntry.State = EntityState.Deleted;
            } else {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual object ExecuteProcedure(string procName, bool executeAsNonQuery = false, params KeyValuePair<string, object>[] parameters) {
            object result = null;

            DbContext.Database.Initialize(false);

            IDbCommand cmd = DbContext.Database.Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;

            foreach (var p in parameters) {
                var dbParam = new SqlParameter(p.Key, p.Value);
                cmd.Parameters.Add(dbParam);
            }

            try {
                DbContext.Database.Connection.Open();
                if (executeAsNonQuery)
                    result = cmd.ExecuteNonQuery();
                else
                    result = cmd.ExecuteScalar();

            } catch (Exception exc) {
                result = exc;
            } finally {
                DbContext.Database.Connection.Close();
            }

            return result;
        }

        #region --- Helper Methods ---

        #endregion

        public virtual long GenerateId(string sequenceName) {
            var newid = DbContext.Database.SqlQuery<long>("SELECT NEXT VALUE FOR " + sequenceName).First();
            return newid;
        }
    }
}
