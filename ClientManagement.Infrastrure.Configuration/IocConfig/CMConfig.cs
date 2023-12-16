using ClientManagement.Domain.UserAgg;
using ClientManagement.Infrastrure.EFCore;
using ClientManagement.Infrastrure.EFCore.Repository;
using FrameWorkUni.FW.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClientManagement.Infrastrure.Configuration.IocConfig
{
    public static class CMConfig
    {
        public static void Config(IServiceCollection service, string connection)
        {

            service.AddTransient<IUserRepository, UserRepository>();

            service.AddSingleton<AuthHelper>();

            service.AddDbContext<ClientContext>(options =>
            {
                options.UseSqlServer(connection);
            });


        }
    }
}
