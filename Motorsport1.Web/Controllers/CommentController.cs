namespace Motorsport1.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Comment;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;

    public class CommentController : BaseController
    {

        private readonly ICommentService commentService;
        private readonly IArticleService articleService;

        public CommentController(ICommentService commentService, IArticleService articleService)
        {
            this.commentService = commentService;
            this.articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int articleId)
        {
            bool exist = await this.articleService.ExistByIdAsync(articleId);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

                return this.RedirectToAction("All", "Article");
            }
            try
            {
                AddAndEditCommentViewModel model = new AddAndEditCommentViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAndEditCommentViewModel model, int articleId)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.commentService.AddAsync(model, articleId);

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedComment;

                return RedirectToAction("All", "Article", new {articleId});
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }

        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction("All", "Article");
        }
    }
}
