using Dapper;
using DbFirstSampleApi.DataAccess.Abstract;
using DbFirstSampleApi.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DbFirstSampleApi.DataAccess.Concrete
{
    public class DapperRepositoryBase<T> : IBaseRepository<T> where T : class, IEntity
    {
        public readonly string _connectionString;
        public DapperRepositoryBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<T> AddAsync(T entity)
        {
            using (IDbConnection db = CreateConnection())
            {
                return (T)await db.QueryAsync<T>($"usp_{nameof(T)}_Create");
            }
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            using (IDbConnection db = CreateConnection())
            { 
                int result = await db.ExecuteAsync($"usp_{nameof(T)}_Delete", new { Id = id });
                return result > 0;
            }
        }
        public async Task<T> GetAsync(T entity)
        {
            using (IDbConnection db = CreateConnection())
            {
                var list = entity.GetType().GetProperties()
                    .Where(p => p.GetValue(entity) != null)
                    .ToList();
                Dictionary<string, object> spParams = new Dictionary<string, object>();

                list.ForEach(x =>
                {
                    spParams.Add(x.Name, x.GetValue(entity));
                });

                return (T)await db.QueryAsync<T>($"usp_{nameof(T)}_Get", spParams); 
            }
        }
        public async Task<T> GetAsync(int id)
        {
            using (IDbConnection db = CreateConnection())
            {
                return (T)await db.QueryAsync<T>($"usp_{nameof(T)}_Get", new { Id = id });
            }
        } 
        public async Task<IEnumerable<T>> GetListAsync()
        {
            using (IDbConnection db = CreateConnection())
            {
                return await db.QueryAsync<T>($"usp_{nameof(T)}_GetList");
            }
        } 
        public async Task<bool> UpdateAsync(T entity)
        {
            using (IDbConnection db = CreateConnection())
            {
                var list = entity.GetType().GetProperties()
                    .Where(p => p.GetValue(entity) != null)
                    .ToList(); 
                Dictionary<string, object> spParams = new Dictionary<string, object>();

                list.ForEach(x =>
                { 
                    spParams.Add(x.Name, x.GetValue(entity)); 
                }); 
                 
                int result = await db.ExecuteAsync($"usp_{nameof(T)}_Update", spParams);
                return result > 0;
            }
        } 
    }
}
