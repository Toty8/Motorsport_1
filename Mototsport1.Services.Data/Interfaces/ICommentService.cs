using Motorsport1.Web.ViewModels.Comment;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface ICommentService
    {
        public Task AddAsync(AddAndEditCommentViewModel model, int ìd);

        public Task<bool> ExistByIdAsync(int id);

        public Task<AddAndEditCommentViewModel> GetCommentForEditByIdAsync(int commentId);

        public Task<int> EditAsync(AddAndEditCommentViewModel model, int commentId);

        public Task<string> GetCommentForDeleteByIdAsync(int commentId);
    }
}
