using Merzigo.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merzigo.UserService.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
