using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SpecFlowHelpers.Configuration;
using SpecFlowHelpers.Database.Definitions;
using SpecFlowHelpers.Database.Definitions.Manager;

namespace SpecFlowHelpers.Database.Implementations.Manager
{
    public class DatabaseManagerSqlServer : IDatabaseManager
    {
        #region Data Members

        public bool Disposed;

        #endregion

        #region Private Members

        private SqlConnection _connection;

        private SqlCommand _command;

        private readonly IAppConfiguration _settings;

        public ICollection<DbParameter> OutParameters { get; private set; }

        #endregion

        #region Constructor

        public DatabaseManagerSqlServer(string connectionString, IAppConfiguration settings)
        {
            this._connection = new SqlConnection(connectionString);
            this._settings = settings;
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///  updates output parameters from stored procedure
        /// </summary>
        private void UpdateOutParameters()
        {
            if (this._command.Parameters.Count > 0)
            {
                this.OutParameters = new List<DbParameter>();

                for (int i = 0; i < this._command.Parameters.Count; i++)
                {
                    if (this._command.Parameters[i].Direction == ParameterDirection.Output || this._command.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        this.OutParameters.Add(new DbParameter(this._command.Parameters[i].ParameterName,
                                                          this._command.Parameters[i].Direction,
                                                          this._command.Parameters[i].Value));
                    }
                }
            }
        }

        /// <summary>
        /// executes query or stored procedure with DB parameteres if they are passed according to the execution type
        /// </summary>
        /// <param name="commandString"></param>
        /// <param name="executeType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private object Execute(string commandString, ExecutionType executeType, IEnumerable<DbParameter> parameters)
        {
            object returnObject = null;

            if (_connection != null)
            {

                _command = new SqlCommand(commandString, this._connection) {CommandType = CommandType.StoredProcedure};
                
                // pass stored procedure parameters to command
                if (parameters != null && parameters.Any())
                {
                    _command.Parameters.Clear();

                    foreach (DbParameter dbParameter in parameters)
                    {
                        if (dbParameter.Value == null)
                        {
                            dbParameter.Value = DBNull.Value;
                        }

                        _command.Parameters.AddWithValue(dbParameter.Name, dbParameter.Value);
                        _command.Parameters[dbParameter.Name].Direction = dbParameter.Direction;

                        if (dbParameter.Size > 0)
                        {
                            _command.Parameters[dbParameter.Name].Size = dbParameter.Size;
                        }
                    }
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                _command.CommandTimeout = this._settings.CommandTimeoutSql;

                switch (executeType)
                {
                    case ExecutionType.Procedure:
                        returnObject = _command.ExecuteReader();
                        break;
                    case ExecutionType.Query:
                        _command.CommandType = CommandType.Text;
                        returnObject = _command.ExecuteReader();
                        break;
                    case ExecutionType.NonQuery:
                        returnObject = _command.ExecuteNonQuery();
                        break;
                    case ExecutionType.Scalar:
                        returnObject = _command.ExecuteScalar();
                        break;
                    default:
                        break;
                }

            }

            return returnObject;
        }

        /// <summary>
        /// executes list query stored procedure and maps result generic list of objects with Mapper especified
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandString"></param>
        /// <param name="executeType"></param>
        /// <param name="parameters
        private IEnumerable<TEntity> ExecuteList<TEntity>(string commandString, ExecutionType executeType, IEnumerable<DbParameter> parameters, IDataReaderEntityMapper<TEntity> dataReaderMapper) where TEntity : new()
        {
            var reportDataItems = new List<TEntity>();

            var reader = (IDataReader)this.Execute(commandString, executeType, parameters);

            while (reader.Read())
            {
                var itemReport = new TEntity();
                itemReport = dataReaderMapper.MapToEntity(reader);
                reportDataItems.Add(itemReport);
            }

            reader.Close();

            UpdateOutParameters();

            return reportDataItems;
        }

    #endregion

        #region IDatabaseManager Members

        /// <summary>
        /// Get A scalar Value 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalarQuery(string procedureName, IEnumerable<DbParameter> parameters)
        {
            return this.Execute(procedureName, ExecutionType.Scalar, parameters);
        }

   
        public void ExecuteNonQuery(string procedureName, IEnumerable<DbParameter> parameters, ExecutionType executionType)
        {
            if (_connection != null)
            {
                this.Execute(procedureName, executionType, parameters);
            }

            UpdateOutParameters();
        }

        /// <summary>
        ///  executes list query stored procedure without parameters
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public IEnumerable<TEntity> ExecuteList<TEntity>(string procedureName) where TEntity : new()
        {
            return ExecuteList<TEntity>(procedureName, null);
        }

        /// <summary>
        /// executes list query stored procedure and maps result generic list of objects
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> ExecuteList<TEntity>(string procedureName, IEnumerable<DbParameter> parameters) where TEntity : new()
        {
            return this.ExecuteList<TEntity>(procedureName, parameters, new DefaultReaderEntityMapper<TEntity>());
        }

        /// <summary>
        /// executes list query stored procedure and maps result generic list of objects with Mapper especified
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>        
        public IEnumerable<TEntity> ExecuteList<TEntity>(string procedureName, IEnumerable<DbParameter> parameters, IDataReaderEntityMapper<TEntity> dataReaderMapper) where TEntity : new()
        {
            return this.ExecuteList<TEntity>(procedureName, ExecutionType.Procedure, parameters, dataReaderMapper);
        }

        /// <summary>
        /// Creates a new connection if the connection is null
        /// </summary>
        public void CreateConnection()
        {
            if (this._connection == null)
            {
                this._connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RentingColombiaSqlServer"].ConnectionString);
            }
        }

        #endregion

        #region IDisposable Members

        [ExcludeFromCodeCoverage]
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._command != null)
                {
                    this._command.Dispose();
                    this._command = null;
                }

                if (this._connection != null)
                {
                    if (this._connection.State == ConnectionState.Open)
                    {
                        this._connection.Close();
                    }
                    this._connection.Dispose();
                    this._connection = null;
                }

                this.Disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion
    }
}
