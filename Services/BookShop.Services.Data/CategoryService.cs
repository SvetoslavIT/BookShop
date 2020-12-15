namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
            => this.categoryRepository = categoryRepository;

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            => await this.categoryRepository
                .AllAsNoTracking()
                .To<T>()
                .ToListAsync();

        public Task<bool> DoesCategoryExistAsync(int id)
            => this.categoryRepository
                .AllAsNoTracking()
                .AnyAsync(x => x.Id == id);

        public Task<string> GetNameByIdAsync(int id)
            => this.categoryRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();
    }
}
