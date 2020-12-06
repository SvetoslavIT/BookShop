namespace BookShop.Services.Data
{
    using System.Threading.Tasks;

    using BookShop.Data.Common.Repositories;
    using BookShop.Data.Models;
    using BookShop.Services.Mapping;
    using BookShop.Web.ViewModels.Comments;
    using Microsoft.EntityFrameworkCore;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepository)
            => this.commentsRepository = commentsRepository;

        public async Task<int> CreateAsync(CreateCommentModel model)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<Comment>(model);

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            return comment.Id;
        }

        public Task<bool> DoesCommentExistAsync(int id)
            => this.commentsRepository
                .AllAsNoTracking()
                .AnyAsync(x => x.Id == id);

        public async Task<Comment> DeleteAsync(int id)
        {
            var comment = await this.commentsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.commentsRepository.Delete(comment);

            return comment;
        }
    }
}
