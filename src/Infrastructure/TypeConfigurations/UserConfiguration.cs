using Core.EntityConfigurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.UserName).HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.UserName).IsUnique();
            builder.Property(e => e.Password).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.Property(e => e.PhoneNum).HasMaxLength(20);

        }
    }
}
