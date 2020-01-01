using CoinFac.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinFac.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(p => p.Goal);
            builder.Property(p => p.AccountType)
                   .IsRequired();
            builder.Property(p => p.Comments)
                   .HasMaxLength(100);
            builder.HasOne(m => m.User)
                   .WithMany(m => m.Accounts)
                   .HasForeignKey(c => c.UserForeignKey);

        }
    }
}
