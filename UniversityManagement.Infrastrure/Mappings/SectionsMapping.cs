using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityManagement.Domain.SectionAgg;

namespace UniversityManagement.Infrastrure.Mappings
{
    internal class SectionsMapping : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.ReportCards)
                .WithOne(x => x.Section)
                .HasForeignKey(x=>x.SectionID);

        }
    }
}
