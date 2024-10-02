using Microsoft.AspNetCore.JsonPatch;
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
	public IActionResult GetComment(Guid postId, Guid id)
	{
		var comment = _service.CommentService.GetComment(postId, id, trackChanges: false);
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
		if (comment is null)
			return BadRequest("CommentCreationDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		var userId = "1";

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

	[HttpPut("{id:guid}")]
	public IActionResult UpdatePostComment(Guid postId, Guid id, [FromBody] CommentUpdateDto comment)
	{
		if (comment is null)
			return BadRequest("CommentForUpdateDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		var userId = "1";

		_service.CommentService.UpdatePostComment(postId, userId, id, comment, postTrackChanges: false, commentTrackChanges: true);

		return NoContent();
	}

	[HttpPatch("{id:guid}")]
	public IActionResult PartiallyUpdatePostComment(Guid postId, Guid id, [FromBody] JsonPatchDocument<CommentUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc object sent from client is null.");

		var result = _service.CommentService.GetCommentForPatch(postId, id, postTrackChanges: false, commentTrackChanges: true);

		patchDoc.ApplyTo(result.commentToPatch, ModelState);

		TryValidateModel(result.commentToPatch);

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		_service.CommentService.SaveForPatch(result.commentToPatch, result.commentEntity);

		return NoContent();
	}
}
