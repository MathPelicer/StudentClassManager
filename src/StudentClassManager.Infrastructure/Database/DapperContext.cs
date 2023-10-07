using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using StudentClassManager.Infrastructure.Interfaces;
using System.Data.Common;

namespace StudentClassManager.Infrastructure.Database
{
    public static class DapperContext
    {
        public static void AddDapperSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbConnection>(provider =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

    }
}
