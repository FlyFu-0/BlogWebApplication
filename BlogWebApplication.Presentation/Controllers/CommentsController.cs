using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace BlogWebApplication.Presentation.Controllers;

[Route("api/posts/{postId}/comments")]
[ApiController]
public class CommentsController : ControllerBase
{
	private readonly IServiceManager _service;

	public CommentsController(IServiceManager service)
	{
		_service = service;
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetComment(Guid postId, Guid commentId)
	{
		var comment = _service.CommentService.GetComment(postId, commentId, trackChanges: false);
		return Ok(comment);
	}

	[HttpGet]
	public IActionResult GetPostComments(Guid postId)
	{
		var comments = _service.CommentService.GetPostComments(postId, trackChanges: false);
		return Ok(comments);
	}
}
