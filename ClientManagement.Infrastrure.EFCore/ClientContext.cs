using ClientManagement.Domain.TokenAgg;
using ClientManagement.Domain.UserAgg;
using ClientManagement.Infrastrure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ClientManagement.Infrastrure.EFCore
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assamble=typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assamble);
            base.OnModelCreating(modelBuilder);
        }


    }
}
