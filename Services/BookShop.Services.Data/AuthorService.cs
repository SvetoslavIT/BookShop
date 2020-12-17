namespace BookShop.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> authorsRepository;

        public AuthorService(IRepository<Author> authorsRepository)
            => this.authorsRepository = authorsRepository;

        public Task<bool> DoesCategoryExistAsync(int id)
            => this.authorsRepository
                .AllAsNoTracking()
                .AnyAsync(x => x.Id == id);

        public Task<string> GetNameByIdAsync(int id)
            => this.authorsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => x.FullName)
                .FirstOrDefaultAsync();
    }
}
