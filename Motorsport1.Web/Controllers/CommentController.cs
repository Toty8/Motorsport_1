﻿namespace Motorsport1.Web.Controllers
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
                AddAndEditCommentViewModel model = new AddAndEditCommentViewModel();

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAndEditCommentViewModel model, int id)
        {

            if (!this.ModelState.IsValid)
            {
                this.TempData[ErrorMessage] = ErrorMessages.InvalidModelState;

                return this.View(model);
            }

            try
            {
                await this.commentService.AddAsync(model, id);

                this.TempData[SuccessMessage] = SuccessMessages.SuccessfullyAddedComment;

                return RedirectToAction("Details", "Article", new {id});
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
            try
            {
                var model = await this.commentService.GetCommentForEditByIdAsync(commentId);

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddAndEditCommentViewModel model,  int commentId)
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
            try
            {
                var model = await this.commentService.GetCommentForDeleteByIdAsync(commentId);

                return View(model);
            }
            catch (Exception e)
            {
                return this.GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, ErrorMessages.UnexpectedError);

            return this.RedirectToAction("All", "Article");
        }
    }
}
