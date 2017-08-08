namespace Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    using Dapper;

    using Domain.Entities;

    public abstract class Repository<TEntity> : IDisposable
        where TEntity : BaseEntity, new()
    {
        private IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        /// <summary>
        /// Connection to database
        /// </summary>
        protected IDbConnection DbConnection => this.dbConnection;

        /// <summary>
        /// Adds a collection of TEntity
        /// </summary>
        /// <param name="entities"><see cref="IEnumerable{T}"/>the collection to be added</param>
        public abstract void Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Adds an TEnitity
        /// </summary>
        /// <param name="entity">The TEntity to be added</param>
        public abstract void Add(TEntity entity);

        /// <summary>
        /// Returns a TEntity by id
        /// </summary>
        /// <param name="id">the TEntity id</param>
        /// <returns><see cref="TEntity"/>entity</returns>
        public abstract TEntity GetById(Guid id);

        /// <summary>
        /// Updates a TEntity
        /// </summary>
        /// <param name="entity"><see cref="TEntity"/>the entity to be updated</param>
        public abstract void Update(TEntity entity);

        /// <summary>
        /// Updated a collection of TEntity
        /// </summary>
        /// <param name="entities"><see cref="IEnumerable{T}"/>the collection to be updated</param>
        public abstract void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes a collection of TEntity
        /// </summary>
        /// <param name="entities"><see cref="IEnumerable{T}"/>the collection to be deleted</param>
        public abstract void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes a TEntity
        /// </summary>
        /// <param name="entity">the entity to be deleted</param>
        public abstract void Delete(TEntity entity);

        /// <summary>
        /// Disposes the connection to database
        /// </summary>
        public void Dispose()
        {
            this.dbConnection?.Dispose();
        }
    }
}