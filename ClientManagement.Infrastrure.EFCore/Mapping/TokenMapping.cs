using ClientManagement.Domain.TokenAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagement.Infrastrure.EFCore.Mapping
{
    public class TokenMapping : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithOne(x => x.Token);
        }
    }
}
