﻿using Microsoft.AspNetCore.Mvc;
using PresentationFacade.ProductComment;
using PresentationFacade.ProductComment.Service;
using WebApplication.Areas.Admin.Models.Comment;

namespace WebApplication.Areas.Admin.Controllers;
public class CommentController : AdminControllerBase
{
    private readonly ICommentService _service;
    private readonly IProductCommentFacade _commentFacade;
    public CommentController(ICommentService service , IProductCommentFacade commentFacade)
    {
        _service = service;
        _commentFacade = commentFacade;
    }

    public IActionResult Index()
    {
        var comment = _service.GetAllCommentsForAdmin();
        return View(comment.MapList());
    }


    [Route("/Admin/Comment/Delete/{CommentId?}")]
    public IActionResult Delete(long CommentId)
    {
        _commentFacade.Delete(CommentId);
        return Redirect("/Admin/Comment");
    }
}