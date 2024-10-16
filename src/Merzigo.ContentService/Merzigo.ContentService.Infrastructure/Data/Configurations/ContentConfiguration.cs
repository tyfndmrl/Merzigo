using Merzigo.ContentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merzigo.ContentService.Infrastructure.Data.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ImageUrl).HasMaxLength(500);
            builder.Property(x => x.VideoUrl).HasMaxLength(500);
            builder.Property(x => x.Tags).HasMaxLength(100);
            builder.Property(x => x.Category).HasMaxLength(100);
            builder.Property(x => x.Language).HasMaxLength(100);
        }
    }
}
