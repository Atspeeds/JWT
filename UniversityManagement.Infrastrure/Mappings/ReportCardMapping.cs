using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Domain.ReportCardAgg;

namespace UniversityManagement.Infrastrure.Mappings
{
    internal class ReportCardMapping : IEntityTypeConfiguration<ReportCard>
    {
        public void Configure(EntityTypeBuilder<ReportCard> builder)
        {

            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Student).WithMany(x => x.ReportCards);

            builder.HasOne(x => x.Section).WithMany(x => x.ReportCards);



        }
    }
}
