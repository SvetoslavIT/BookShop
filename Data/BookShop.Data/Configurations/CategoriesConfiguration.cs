namespace BookShop.Data.Configurations
{
    using BookShop.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.Property(x => x.Name).IsUnicode();
        }
    }
}
