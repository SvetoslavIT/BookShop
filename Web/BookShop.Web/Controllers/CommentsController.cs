namespace BookShop.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using BookShop.Services.Data;
    using BookShop.Web.ViewModels.Comments;
    using BookShop.Data.Models;

    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
            => this.commentService = commentService;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CreateCommentModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.commentService.CreateAsync(model);

            return this.Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<Comment>> Delete(int id)
        {
            //To do admin ifs
            if (!await this.commentService.DoesCommentExistAsync(id))
            {
                return this.BadRequest();
            }

            var comment = await this.commentService.DeleteAsync(id);

            return this.Ok(comment);
        }
    }
}
