using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// SQL Link, REUSABLE!!! SAVE!!!! INJECTION PREVENTION HELPFUL!!!!
        /// </summary>
        /// <typeparam name="T">Type stored procedures</typeparam>
        /// <typeparam name="U">parameter types to be passed into</typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public async Task<List<T>> LoadData<T, U>(string storedProcedure,
                                                  U parameters,
                                                  string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure,
                                                          parameters,
                                                          commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        /// <summary>
        /// SQL Link that saves data in, REUSABLE!!!! SAVE!!! INJECTION PREVENTION HELPFUL!!!
        /// </summary>
        /// <typeparam name="U">Data being passed in</typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public async Task<int> SaveData<U>(string storedProcedure,
                                           U parameters,
                                           string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<U>(storedProcedure,
                                                          parameters,
                                                          commandType: CommandType.StoredProcedure);

                return await connection.ExecuteAsync(storedProcedure,
                                                     parameters,
                                                     commandType: CommandType.StoredProcedure);
            }
        }
    }
}
