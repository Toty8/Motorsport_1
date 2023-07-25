using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(AddAndEditCommentViewModel model, int id)
        {
            Comment comment = new Comment()
            {
                Content = model.Content,
                ArticleId = id,
            };

            await this.dbContext.Comments.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> EditAsync(AddAndEditCommentViewModel model, int commentId)
        {
            Comment comment = await this.dbContext.Comments
                .Where(c => c.Id == commentId)
                .FirstAsync();

            comment.Content = model.Content;

            await this.dbContext.SaveChangesAsync();

            return comment.ArticleId;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await this.dbContext.Comments.AnyAsync(c => c.Id == id);
        }

        public async Task<string> GetCommentForDeleteByIdAsync(int commentId)
        {
            string content = await this.dbContext.Comments
                .Where(c => c.Id == commentId)
                .Select(c => c.Content)
                .FirstAsync();

            return content;
        }

        public async Task<AddAndEditCommentViewModel> GetCommentForEditByIdAsync(int commentId)
        {
            AddAndEditCommentViewModel comment = await this.dbContext.Comments
                .Where(c => c.Id == commentId)
                .Select(c => new AddAndEditCommentViewModel
                {
                    Content = c.Content,
                })
                .FirstAsync();

            return comment;
        }
    }
}
