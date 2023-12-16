using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversityManagement.Application;
using UniversityManagement.Application.Conteract.StudentCo;
using UniversityManagement.Domain.StudentAgg;
using UniversityManagement.Infrastrure;
using UniversityManagement.Infrastrure.Repository;

namespace UniVersityManagement.Infrastrure.Configuration.IocConfig
{
    public static class UMConfig
    {
        public static void Config(IServiceCollection service,string connection)
        {

            service.AddTransient<IStudentRepository, StudentRepository>();

            service.AddTransient<IStudentApplication, StudentApplication>();
            
            service.AddDbContext<UniManagementContext>(options =>
            {
                options.UseSqlServer(connection);
            });


        }
        

    }
}
