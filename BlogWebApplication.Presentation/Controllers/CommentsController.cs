﻿using BlogWebApplication.Presentation.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO.CommetDtos;
using Shared.RequestFeatures;
using System.Text.Json;

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
	public async Task<IActionResult> GetComment(Guid postId, Guid id)
	{
		var comment = await _service.CommentService.GetCommentAsync(postId, id, trackChanges: false);
		return Ok(comment);
	}

	[HttpGet]
	public async Task<IActionResult> GetPostComments(Guid postId, [FromQuery] CommentParameters commentParametrs)
	{
		var pagedResult = await _service.CommentService.GetPostCommentsAsync(postId, commentParametrs, trackChanges: false);

		Response.Headers.Add("X-Pagination",
			JsonSerializer.Serialize(pagedResult.metaData));

		return Ok(pagedResult.commentDtos);
	}

	[HttpPost]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
	public async Task<IActionResult> CreateComment(Guid postId, [FromBody] CommentCreationDto comment)
	{
		if (comment is null)
			return BadRequest("CommentCreationDto object is null");

		var userId = "1";

		var createdComment = await _service.CommentService.CreateCommentAsync(postId, userId, comment, trackChanges: false);
		return CreatedAtRoute("CommentById", new { postId, id = createdComment.Id }, createdComment);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteComment(Guid postId, Guid id)
	{
		var userId = "1";

		await _service.CommentService.DeletePostCommentAsync(postId, userId, id, trackChanges: false);
		return NoContent();
	}

	[HttpPut("{id:guid}")]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
	public async Task<IActionResult> UpdatePostComment(Guid postId, Guid id, [FromBody] CommentUpdateDto comment)
	{
		if (comment is null)
			return BadRequest("CommentForUpdateDto object is null");

		var userId = "1";

		await _service.CommentService.UpdatePostCommentAsync(postId, userId, id, comment, postTrackChanges: false, commentTrackChanges: true);

		return NoContent();
	}

	[HttpPatch("{id:guid}")]
	public async Task<IActionResult> PartiallyUpdatePostComment(Guid postId, Guid id, [FromBody] JsonPatchDocument<CommentUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc object sent from client is null.");

		var result = await _service.CommentService.GetCommentForPatchAsync(postId, id, postTrackChanges: false, commentTrackChanges: true);

		patchDoc.ApplyTo(result.commentToPatch, ModelState);

		TryValidateModel(result.commentToPatch);

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.CommentService.SaveForPatchAsync(result.commentToPatch, result.commentEntity);

		return NoContent();
	}
}
