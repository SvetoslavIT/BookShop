namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.categoryRepository
                .AllAsNoTracking()
                .To<T>()
                .ToListAsync();
    }
}
