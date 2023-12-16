using Microsoft.EntityFrameworkCore;
using UniversityManagement.Domain.ReportCardAgg;
using UniversityManagement.Domain.SectionAgg;
using UniversityManagement.Domain.StudentAgg;

namespace UniversityManagement.Infrastrure
{
    public class UniManagementContext : DbContext
    {
        public UniManagementContext(DbContextOptions<UniManagementContext> options) : base(options)
        {
        }


        #region Table Set

        public DbSet<Student> Students { get; set; }
        public DbSet<Section>  Sections { get; set; }
        public DbSet<ReportCard> ReportCards { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assambaly = typeof(Student).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambaly);

            base.OnModelCreating(modelBuilder);
        }


    }
}
