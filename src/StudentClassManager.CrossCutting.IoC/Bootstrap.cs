using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentClassManager.Application.Services;
using StudentClassManager.Application.Services.Interfaces;
using StudentClassManager.Domain.Interfaces;
using StudentClassManager.Infrastructure.Database;
using StudentClassManager.Infrastructure.Repositories;

namespace StudentClassManager.CrossCutting.IoC
{
    public static class Bootstrap
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDapperSqlServer(configuration.GetConnectionString("MySQLServer"));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IClassStudentRepository, ClassStudentRepository>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IClassStudentService, ClassStudentService>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}