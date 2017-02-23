using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace NywFleet.Data.Helpers
{
   
    public class RepositoryFactories
    {
        /// <summary>
        /// Return the runtime Radar repository factory functions,
        /// each one is a factory for a repository of a particular type.
        /// </summary>
        /// <remarks>
        /// MODIFY THIS METHOD TO ADD CUSTOM Radar FACTORY FUNCTIONS
        /// </remarks>
        private IDictionary<Type, Func<DbContext, object>> GetRadarFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                {                  

                };
        }

        /// <summary>
        /// Constructor that initializes with runtime Radar repository factories
        /// </summary>
        public RepositoryFactories()  
        {
            _repositoryFactories = GetRadarFactories();
        }


        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories )
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
       
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EfRepository<T>(dbContext);
        }

       
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

    }
}
