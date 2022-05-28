using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    public SqlDataAccess()
    {
        
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    {
        using IDbConnection connection = new SqlConnection(connectionId);
        List<T> data = new List<T>();
        data = (List<T>)await connection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure);
        return data;
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    {
        using IDbConnection connection = new SqlConnection(connectionId);
        await connection.ExecuteAsync(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
