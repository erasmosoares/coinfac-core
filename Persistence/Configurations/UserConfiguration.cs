using CoinFac.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinFac.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.GivenName);
            builder.Property(p => p.FamilyName);
            builder.Property(p => p.Name);
            builder.Property(p => p.PictureUrl);
            builder.Property(p => p.Locale);
            builder.Property(p => p.UpdatedAt);
            builder.Property(p => p.Email);
            builder.Property(p => p.EmailVerified);
            builder.Property(p => p.Sub);
        }
    }
}
