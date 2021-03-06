﻿namespace BookShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<bool> DoesCategoryExistAsync(int id);

        Task<string> GetNameByIdAsync(int id);
    }
}
