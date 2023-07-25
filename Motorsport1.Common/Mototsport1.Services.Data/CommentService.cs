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

        public async Task AddAsync(AddEditAndDeleteCommentViewModel model, int id)
        {
            Comment comment = new Comment()
            {
                Content = model.Content,
                ArticleId = id,
            };

            await this.dbContext.Comments.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int commentId)
        {
            Comment comment = await this.dbContext.Comments
                .Where(c => c.IsActive == true)
                .FirstAsync(c => c.Id == commentId);

            comment.IsActive = false;

            await this.dbContext.SaveChangesAsync();

            return comment.ArticleId;
        }

        public async Task<int> EditAsync(AddEditAndDeleteCommentViewModel model, int commentId)
        {
            Comment comment = await this.dbContext.Comments
                .Where(c => c.IsActive == true)
                .FirstAsync(c => c.Id == commentId);

            comment.Content = model.Content;

            await this.dbContext.SaveChangesAsync();

            return comment.ArticleId;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await this.dbContext.Comments
                .Where(c => c.IsActive == true)
                .AnyAsync(c => c.Id == id);
        }

        public async Task<AddEditAndDeleteCommentViewModel> GetCommentForDeleteByIdAsync(int commentId)
        {
            string content = await this.dbContext.Comments
                .Where(c => c.Id == commentId && c.IsActive == true)
                .Select(c => c.Content)
                .FirstAsync();

            AddEditAndDeleteCommentViewModel viewModel = new AddEditAndDeleteCommentViewModel()
            {
                Content = content,
            };

            return viewModel;
        }

        public async Task<AddEditAndDeleteCommentViewModel> GetCommentForEditByIdAsync(int commentId)
        {
            AddEditAndDeleteCommentViewModel comment = await this.dbContext.Comments
                .Where(c => c.Id == commentId && c.IsActive == true)
                .Select(c => new AddEditAndDeleteCommentViewModel
                {
                    Content = c.Content,
                })
                .FirstAsync();

            return comment;
        }
    }
}
