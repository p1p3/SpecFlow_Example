using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowHelpers.Database.Definitions;
using SpecFlowHelpers.Database.Definitions.Manager;
using SpecFlowHelpers.Database.Implementations.Manager;
using System.Transactions;

namespace SpecFlowHelpers.Database.Implementations
{
    public class TeprestaFunctions : ITeprestaFunctions, IDisposable
    {
        private readonly IDatabaseManager _dataBaseManager;
        private readonly IDatabaseManager _securityDabtaDatabaseManager;

        public TeprestaFunctions(IDatabaseManager dataBaseManager,IDatabaseManager securityDabtaDatabaseManager)
        {
            _dataBaseManager = dataBaseManager;
            _securityDabtaDatabaseManager = securityDabtaDatabaseManager;
        }

        #region Implementation of ITeprestaFunctions

        public void DeleteUser(string userEmail)
        {
            using (var scope = new TransactionScope())
            {
                using (this._dataBaseManager)
                {
                    this._dataBaseManager.CreateConnection();
                    var queryString = GetDeleteUserInformationQuery(userEmail);
                    this._dataBaseManager.ExecuteNonQuery(queryString, null, ExecutionType.Query);
                }
                using (this._securityDabtaDatabaseManager)
                {
                    this._securityDabtaDatabaseManager.CreateConnection();
                    var queryString = GetDeleteUserSecurityQuery(userEmail);
                    this._securityDabtaDatabaseManager.ExecuteNonQuery(queryString, null, ExecutionType.Query);
                }
                scope.Complete();
            }
        }


        #endregion

        #region Private methods

        private string GetDeleteUserInformationQuery(string userEmail)
        {
            var query = $" DELETE FROM [dbo].UserAditionalInformation WHERE UserLogin = '{userEmail}' ";

            return query;
        }

        private string GetDeleteUserSecurityQuery(string userEmail)
        {
            var builder = new StringBuilder();
            builder.Append($" DECLARE @Email VARCHAR(255) = '{userEmail}' ");
            builder.Append(" DECLARE @UserId UNIQUEIDENTIFIER ");
            builder.Append(" SELECT @UserId = Id FROM [dbo].[AspNetUsers]  usr WHERE Email = @Email");
            builder.Append(" DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = @UserId ");
            builder.Append(" DELETE FROM [dbo].[AspNetUserClaims] WHERE UserId = @UserId ");
            builder.Append(" DELETE FROM [dbo].[AspNetUsers] WHERE Id = @UserId ");

            return builder.ToString();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}
