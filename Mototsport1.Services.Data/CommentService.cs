using Motorsport1.Data;
using Motorsport1.Data.Models;
using Motorsport1.Web.ViewModels.Comment;
using Mototsport1.Services.Data.Interfaces;

namespace Mototsport1.Services.Data
{
    public class CommentService : ICommentService
    {
        private readonly Motorsport1DbContext dbContext;

        public CommentService(Motorsport1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(AddAndEditCommentViewModel model, int articleId)
        {
            Comment comment = new Comment()
            {
                Content = model.Content,
                ArticleId = articleId,
            };

            await this.dbContext.Comments.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
