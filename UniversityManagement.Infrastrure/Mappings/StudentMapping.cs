using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Domain.StudentAgg;

namespace UniversityManagement.Infrastrure.Mappings
{
    internal class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ReportCards)
                .WithOne(x => x.Student)
                .HasForeignKey(x=>x.StudentID);


        }
    }
}
