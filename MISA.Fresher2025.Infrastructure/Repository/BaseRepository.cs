using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Fresher2025.Core.Interfaces.Repository;
using MySqlConnector;
using System.Data;
using static Dapper.SqlMapper;

namespace MISA.Fresher2025.Infrastructure.Repository
{
    public class BaseRepository<T>: IBaseRepository<T>, IDisposable where T : class 
    {
        protected readonly string? connectionString;
        protected IDbConnection dbConnection;
        public BaseRepository(IConfiguration config) {
            connectionString = config.GetConnectionString("MISA.Fresher2025");
            dbConnection = new MySqlConnection(connectionString);
        }

        public List<T> Get()
        {
            var tableName = typeof(T).Name;
            var sqlCommand = $"SELECT * FROM {tableName}";
            return dbConnection.Query<T>(sqlCommand).ToList();
        }

        public T GetById(Guid id)
        {
            var tableName = typeof(T).Name;
            var sqlCommand = $"SELECT * FROM {tableName} WHERE ID = @id";
            return dbConnection.QuerySingleOrDefault<T>(sqlCommand, new { ID = id });
        }

        public T Insert(T entity)
        {
            return entity;
        }

        public T Update(T entity)
        {
            return entity;
        }

        public T Delete(Guid id)
        {
            var tableName = typeof(T).Name;
            var sqlCommand = $"SELECT * FROM {tableName} WHERE ID = @id";
            return dbConnection.QuerySingleOrDefault<T>(sqlCommand, new { ID = id });
        }

        public void Dispose() // Đóng kết nối database tự động chạy không cần gọi
        {
            dbConnection?.Dispose();
        }
    }
}
