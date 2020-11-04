namespace BookShop.Data.Configurations
{
    using BookShop.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentsConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment.Property(x => x.Description).IsUnicode();
        }
    }
}
