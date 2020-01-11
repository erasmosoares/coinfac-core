using CoinFac.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinFac.Persistence.Configurations
{
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Value)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(p => p.Date)
                   .IsRequired();
            builder.Property(p => p.Notes);
            builder.HasOne(m => m.Account)
                   .WithMany(m => m.Records)
                   .HasForeignKey(c => c.AccountId);
        }
    }
}
