// using System.Threading.Tasks;
// using svietnamAPI.Repositories.Interfaces;
// using svietnamAPI.Infastructure.Data;
// using System;
// using System.Data.SqlClient;
// using System.Data;

// namespace svietnamAPI.Repositories.Implements
// {
//     public abstract partial class GenericDbRepository : GenericRepository, IGenericDbRepository
//     {
//             public GenericDbRepository(IDataConnectionFactory dataConnectionFactory)
//         : base(dataConnectionFactory)
//         {

//         }

//         // use for buffered queries that return a type
//         protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> queryData)
//         {
//             try
//             {
//                 await using (var dbConnection = _dataConnectionFactory.CreateSqlDbConnection())
//                 {
//                     await dbConnection.OpenAsync();
//                     return await queryData(dbConnection);
//                 }
//             }
//             catch (TimeoutException ex)
//             {
//                 throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
//             }
//             catch (SqlException ex)
//             {
//                 throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
//             }
//         }

//         // use for buffered queries that do not return a type
//         protected async Task WithConnection(Func<IDbConnection, Task> queryData)
//         {
//             try
//             {
//                 await using (var dbConnection = _dataConnectionFactory.CreateSqlDbConnection())
//                 {
//                     await dbConnection.OpenAsync();
//                     await queryData(dbConnection);
//                 }
//             }
//             catch (TimeoutException ex)
//             {
//                 throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
//             }
//             catch (SqlException ex)
//             {
//                 throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
//             }
//         }

//         //use for non-buffered queries that return a type
//         protected async Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> queryData, Func<TRead, Task<TResult>> processAfterQuery)
//         {
//             try
//             {
//                 await using (var dbConnection = _dataConnectionFactory.CreateSqlDbConnection())
//                 {
//                     await dbConnection.OpenAsync();
//                     var data = await queryData(dbConnection);
//                     return await processAfterQuery(data);
//                 }
//             }
//             catch (TimeoutException ex)
//             {
//                 throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
//             }
//             catch (SqlException ex)
//             {
//                 throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
//             }
//         }
//     }
// }