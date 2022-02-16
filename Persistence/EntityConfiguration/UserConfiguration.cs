using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(owner => owner.Id);
            builder.Property(account => account.Id).ValueGeneratedOnAdd();
            builder.Property(owner => owner.Name).HasMaxLength(60);
            builder.Property(owner => owner.DateOfBirth).IsRequired();
            builder.Property(owner => owner.Address).HasMaxLength(100);
            builder.HasMany(owner => owner.Accounts)
                    .WithOne()
                    .HasForeignKey(account => account.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
