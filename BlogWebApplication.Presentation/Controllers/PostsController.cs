using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO.PostDtos;

namespace BlogWebApplication.Presentation.Controllers;

[Route("api/posts")]
[ApiController]
public class PostsController : ControllerBase
{
	private readonly IServiceManager _service;

	public PostsController(IServiceManager service)
	{
		_service = service;
	}

	[HttpGet]
	public IActionResult GetPosts()
	{
		var posts = _service.PostService.GetAllPosts(trackChanges: false);
		return Ok(posts);
	}

	[HttpGet("{id:guid}", Name = "PostById")]
	public IActionResult GetPost(Guid id)
	{
		var post = _service.PostService.GetPost(id, trackChanges: false);
		return Ok(post);
	}

	[HttpPost]
	public IActionResult CreatePost([FromBody] PostCreationDto post)
	{
		if (post is null)
			return BadRequest("PostCreationDto object is null");

		var createdPost = _service.PostService.CreatePost(post, trackChanges: true);

		return CreatedAtRoute("PostById", new { id = createdPost.Id }, createdPost);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeletePost(Guid id)
	{
		var userId = "1";

		_service.PostService.DeletePost(userId, id, trackChanges: false);
		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpdatePost(Guid id, [FromBody] PostUpdateDto post)
	{
		if (post is null)
			return BadRequest("PostUpdateDto object is null");

		_service.PostService.UpdatePost(id, post, trackChanges: true);
		return NoContent();
	}

	[HttpPatch("{id:guid}")]
	public IActionResult PartiallyUpdatePost(Guid id, [FromBody] JsonPatchDocument<PostUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc object sent from client is null.");

		var result = _service.PostService.GetPostForPatch(id, trackChanges: true);

		patchDoc.ApplyTo(result.postToPatch);

		_service.PostService.SaveToPatch(result.postToPatch, result.postEntity);

		return NoContent();
	}
}
