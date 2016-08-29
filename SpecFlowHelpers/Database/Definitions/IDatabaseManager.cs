using System;
using System.Collections.Generic;
using SpecFlowHelpers.Database.Implementations;
using SpecFlowHelpers.Database.Implementations.Manager;

namespace SpecFlowHelpers.Database.Definitions
{

    public interface IDatabaseManager : IDisposable
    {
        object ExecuteScalarQuery(string procedureName, IEnumerable<DbParameter> parameters);

        ICollection<DbParameter> OutParameters { get; }

        void ExecuteNonQuery(string procedureName, IEnumerable<DbParameter> parameters);

        /// <summary>
        ///  executes list query stored procedure without parameters
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        IEnumerable<TEntity> ExecuteList<TEntity>(string procedureName) where TEntity : new();

        /// <summary>
        /// executes list query stored procedure and maps result generic list of objects
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TEntity> ExecuteList<TEntity>(string procedureName, IEnumerable<DbParameter> parameters) where TEntity : new();

        /// <summary>
        /// executes list query stored procedure and maps result generic list of objects with Mapper especified
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TEntity> ExecuteList<TEntity>(string procedureName, IEnumerable<DbParameter> parameters, IDataReaderEntityMapper<TEntity> dataReaderMapper) where TEntity : new();

        void CreateConnection();
    }
}