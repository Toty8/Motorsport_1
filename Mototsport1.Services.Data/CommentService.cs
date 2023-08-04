using Microsoft.EntityFrameworkCore;
using Motorsport1.Data;
using Motorsport1.Data.Models;
using Motorsport1.Services.Mapping;
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

        public async Task AddAsync(AddEditAndDeleteCommentViewModel model, int id, string userId)
        {
            Comment comment = AutoMapperConfig.MapperInstance.Map<Comment>(model);
            comment.ArticleId = id;
            comment.PublisherId = Guid.Parse(userId);

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

            AutoMapperConfig.MapperInstance.Map(model, comment);


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

            AddEditAndDeleteCommentViewModel viewModel = AutoMapperConfig.MapperInstance.Map<AddEditAndDeleteCommentViewModel>(content);

            return viewModel;
        }

        public async Task<AddEditAndDeleteCommentViewModel> GetCommentForEditByIdAsync(int commentId)
        {
            AddEditAndDeleteCommentViewModel comment = await this.dbContext.Comments
                .Where(c => c.Id == commentId && c.IsActive == true)
                .To<AddEditAndDeleteCommentViewModel>()
                .FirstAsync();

            return comment;
        }

        public async Task<bool> IsUserOwnerOfCommentAsync(int commentId, string userId)
        {
            return await this.dbContext.Comments
            .Include(c => c.Article)
            .Where(c => c.IsActive == true)
            .AnyAsync(c => c.Id == commentId && c.PublisherId.ToString() == userId);
        }
    }
}
