using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NywFleet.Data.Contracts;
using NywFleet.Data.DataContext;
using NywFleet.Data.Helpers;

namespace NywFleet.Data {
    public class FleetUow : IFleetUow, IDisposable {
        public FleetUow() {
            CreateDbContext();
            RepositoryProvider = new RepositoryProvider(new RepositoryFactories()) { DbContext = DbContext };
        }
        //public IRepository<Question> Questions => GetStandardRepo<Question>();
        //public IRepository<Answer> QuestionAnswers => GetStandardRepo<Answer>();

        public int? UserId { get; set; }

        public void Commit() {
            DbContext.UserId = UserId;
            DbContext.SaveChanges();
        }

        public Task<int> CommitAsync() {
            return DbContext.SaveChangesAsync();
        }

        public virtual object ExecuteProcedure(string procedureName, params KeyValuePair<string, object>[] parameters) {
            object result = null;

            DbContext.Database.Initialize(false);

            IDbCommand cmd = DbContext.Database.Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = procedureName;

            foreach (var p in parameters) {
                var dbParam = new SqlParameter(p.Key, p.Value);
                cmd.Parameters.Add(dbParam);
            }

            try {
                DbContext.Database.Connection.Open();
                result = cmd.ExecuteScalar();
            } finally {
                DbContext.Database.Connection.Close();
            }

            return result;
        }

        public List<T> ExecuteProcedureWithResult<T>(string procName, params KeyValuePair<string, object>[] parameters) {
            IDbCommand cmd = DbContext.Database.Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            var paramString = new StringBuilder();
            SqlParameter[] paramsCollection = new SqlParameter[parameters.Length];
            int counter = 0;
            foreach (var p in parameters) {
                paramString.AppendFormat(" @{0}=@{0},", p.Key);
                var dbParam = new SqlParameter("@" + p.Key, p.Value);
                paramsCollection[counter] = dbParam;
                counter++;
                //paramsCollection.Add(dbParam);
            }

            string additionalParams = paramString.ToString();
            if (!string.IsNullOrEmpty(additionalParams))
                additionalParams = additionalParams.Remove(additionalParams.Length - 1);

            if (parameters.Any()) {
                return DbContext.Database.SqlQuery<T>("exec " + procName + " " + additionalParams, paramsCollection).ToList();
            }
            return DbContext.Database.SqlQuery<T>("exec " + procName).ToList();
        }

        protected void CreateDbContext() {
            DbContext = new QTestContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
            DbContext.Configuration.AutoDetectChangesEnabled = true;

        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class {
            return RepositoryProvider.GetRepository<T>();
        }

        private QTestContext DbContext { get; set; }

        #region IDisposable

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                if (DbContext != null) {
                    DbContext.Dispose();
                }
            }
        }

        #endregion


    }
}