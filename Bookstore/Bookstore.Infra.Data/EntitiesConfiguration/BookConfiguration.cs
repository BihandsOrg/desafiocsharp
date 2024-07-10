using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntitiesConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
        builder.Property(p => p.Writer).HasMaxLength(300).IsRequired();
        builder.Property(p => p.ISBNCode).HasMaxLength(300).IsRequired();
        builder.Property(p => p.Publisher).HasMaxLength(300).IsRequired();
        builder.Property(p => p.Price).HasPrecision(10, 2);

        builder.HasOne(e => e.Category).WithMany(e => e.Books)
            .HasForeignKey(e => e.CategoryId);
    }
}
