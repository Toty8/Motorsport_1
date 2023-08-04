namespace Motorsport1.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using Motorsport1.Web.ViewModels.Comment;
    using Mototsport1.Services.Data.Interfaces;
    using static Motorsport1.Common.UIMessages;
    using static Motorsport1.Common.NotificationMessageConstants;
    using Motorsport1.Web.Infrastructure.Extensions;

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
        public async Task<IActionResult> Add(int id)
        {
            bool exist = await this.articleService.ExistByIdAsync(id);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingArticle;

                return this.RedirectToAction("All", "Article");
            }

            try
            {
                AddEditAndDeleteCommentViewModel model = new AddEditAndDeleteCommentViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEditAndDeleteCommentViewModel model, int id)
        {

            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.commentService.AddAsync(model, id, GetUserId());

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedComment;

                return RedirectToAction("Details", "Article", new { id });
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int commentId)
        {
            bool exist = await this.commentService.ExistByIdAsync(commentId);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingComment;

                return this.RedirectToAction("All", "Article");
            }

            bool isUserOwner = await this.commentService.IsUserOwnerOfCommentAsync(commentId, GetUserId());

            if (!this.User.IsAdmin() && !isUserOwner)
            {
                this.TempData[ErrorMessage] = ErrorMessages.NotYourComment;

                return this.RedirectToAction("All", "Article");
            }

            try
            {
                var model = await this.commentService.GetCommentForEditByIdAsync(commentId);

                return this.View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEditAndDeleteCommentViewModel model, int commentId)
        {
            bool exist = await this.commentService.ExistByIdAsync(commentId);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingComment;

                return this.RedirectToAction("All", "Article");
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                int id = await this.commentService.EditAsync(model, commentId);

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyEditedComment;

                return RedirectToAction("Details", "Article", new { id });
            }

            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int commentId)
        {
            bool exist = await this.commentService.ExistByIdAsync(commentId);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingComment;

                return this.RedirectToAction("All", "Article");
            }

            bool isUserOwner = await this.commentService.IsUserOwnerOfCommentAsync(commentId, GetUserId());

            if (!this.User.IsAdmin() && !isUserOwner)
            {
                this.TempData[ErrorMessage] = ErrorMessages.NotYourComment;

                return this.RedirectToAction("All", "Article");
            }

            try
            {
                var model = await this.commentService.GetCommentForDeleteByIdAsync(commentId);

                return this.View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AddEditAndDeleteCommentViewModel model, int commentId)
        {
            bool exist = await this.commentService.ExistByIdAsync(commentId);

            if (exist == false)
            {
                this.TempData[ErrorMessage] = ErrorMessages.UnexistingComment;

                return this.RedirectToAction("All", "Article");
            }

            try
            {
                int id = await this.commentService.DeleteAsync(commentId);

                this.TempData[InformationMessage] = InformationMessages.InformationDeletedComment;

                return RedirectToAction("Details", "Article", new { id });
            }

            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

                return this.View(model);
            }
        }
    }
}
