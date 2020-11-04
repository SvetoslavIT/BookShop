namespace BookShop.Data.Configurations
{
    using BookShop.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AuthorBooksConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> authorBook)
        {
            authorBook.HasKey(x => new { x.BookId, x.AuthorId });

            authorBook
                .HasOne(x => x.Author)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
