using System.Data.Common;
using Dapper;
using Angular.NET.Enums;

namespace Angular.NET.Data
{
    public class DbController
    {
        private readonly DbConnection       _connection;
        private readonly ILogger            _logger;

        public DbController(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;
            _connection = ConnectionFactory.GetConnection(configuration.GetValue<ConnectionTypes>("Configuration:ConnectionTypes"),
                                                          configuration.GetValue<string>("Configuration:ConnectionString"));
        }

        public IEnumerable<T>? ExecuteQuery<T>(object? datas, string query)
        {
            using (var connection = _connection)
            {
                try
                {
                    _logger.LogInformation($"{DateTime.Now}");
                    var x = _connection.Query<T>(query,datas);
                    return x;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{DateTime.Now} - Error : {ex.Message}");
                    return null;
                }
            }
        }

        public IEnumerable<T>? ExecuteQuery<T>(string query)
        {
            using (var connection = _connection)
            {
                try
                {
                    _logger.LogInformation($"{DateTime.Now}");
                    var x = _connection.Query<T>(query);
                    return x;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{DateTime.Now} - Error : {ex.Message}");
                    return null;
                }
            }
        }

        //public IEnumerable<Task<T>>? ExecuteQueryAsync<T>(object? datas,string query)
        //{
        //    using (var connection = _connection)
        //    {
        //        try
        //        {
        //            var res = _connection.QueryAsync<T>(query, datas);
        //            _logger.LogInformation($"{DateTime.Now} - Execute query : {res}");
        //            return (IEnumerable<Task<T>>?)res;
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError($"{DateTime.Now} - Error : {ex.Message}");
        //            return null;
        //        }
        //    }
        //}
    }
}
