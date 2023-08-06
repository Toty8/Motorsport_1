using Motorsport1.Web.ViewModels.Comment;

namespace Motorsport1.Services.Data.Interfaces
{
    public interface ICommentService
    {
        public Task AddAsync(AddEditAndDeleteCommentViewModel model, int ìd, string userId);

        public Task<bool> ExistByIdAsync(int id);

        public Task<AddEditAndDeleteCommentViewModel> GetCommentForEditByIdAsync(int commentId);

        public Task<int> EditAsync(AddEditAndDeleteCommentViewModel model, int commentId);

        public Task<AddEditAndDeleteCommentViewModel> GetCommentForDeleteByIdAsync(int commentId);

        public Task<int> DeleteAsync(int commentId);

        public Task<bool> IsUserOwnerOfCommentAsync(int commentId, string userId);
    }
}
