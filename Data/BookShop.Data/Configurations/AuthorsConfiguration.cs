namespace BookShop.Data.Configurations
{
    using BookShop.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AuthorsConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> author)
        {
            author.Property(x => x.FullName).IsUnicode();
        }
    }
}
