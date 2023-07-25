using Motorsport1.Web.ViewModels.Comment;

namespace Mototsport1.Services.Data.Interfaces
{
    public interface ICommentService
    {
        public Task AddAsync(AddAndEditCommentViewModel model, int articleId);
    }
}
