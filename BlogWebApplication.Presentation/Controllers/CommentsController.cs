using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO.CommetDtos;

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

	[HttpGet("{id:guid}", Name = "CommentById")]
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

	[HttpPost]
	public IActionResult CreateComment(Guid postId, [FromBody] CommentCreationDto comment)
	{
		var userId = "1";

		if (comment is null)
			return BadRequest("CommentCreationDto object is null");
		var createdComment = _service.CommentService.CreateComment(postId, userId, comment, trackChanges: false);
		return CreatedAtRoute("CommentById", new { postId, id = createdComment.Id }, createdComment);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteComment(Guid postId, Guid id)
	{
		var userId = "1";

		_service.CommentService.DeletePostComment(postId, userId, id, trackChanges: false);
		return NoContent();
	}
}
