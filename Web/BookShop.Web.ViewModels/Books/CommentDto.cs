namespace BookShop.Web.ViewModels.Books
{
    using System;

    using BookShop.Data.Models;
    using BookShop.Services.Mapping;

    public class CommentDto : IMapFrom<Comment>
    {
        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public string UserFullName { get; set; }
    }
}
