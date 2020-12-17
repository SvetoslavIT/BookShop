namespace BookShop.Services.Data
{
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<bool> DoesCategoryExistAsync(int id);

        Task<string> GetNameByIdAsync(int id);
    }
}
