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
	public async Task<IActionResult> GetPosts()
	{
		var posts = await _service.PostService.GetAllPosts(trackChanges: false);
		return Ok(posts);
	}

	[HttpGet("{id:guid}", Name = "PostById")]
	public async Task<IActionResult> GetPost(Guid id)
	{
		var post = await _service.PostService.GetPost(id, trackChanges: false);
		return Ok(post);
	}

	[HttpPost]
	public async Task<IActionResult> CreatePost([FromBody] PostCreationDto post)
	{
		if (post is null)
			return BadRequest("PostCreationDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		var userId = "1";

		var createdPost = await _service.PostService.CreatePost(userId, post, trackChanges: true);

		return CreatedAtRoute("PostById", new { id = createdPost.Id }, createdPost);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeletePost(Guid id)
	{
		var userId = "1";

		await _service.PostService.DeletePost(userId, id, trackChanges: false);
		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> UpdatePost(Guid id, [FromBody] PostUpdateDto post)
	{
		if (post is null)
			return BadRequest("PostUpdateDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.PostService.UpdatePost(id, post, trackChanges: true);
		return NoContent();
	}

	[HttpPatch("{id:guid}")]
	public async Task<IActionResult> PartiallyUpdatePost(Guid id, [FromBody] JsonPatchDocument<PostUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc object sent from client is null.");

		var result = await _service.PostService.GetPostForPatch(id, trackChanges: true);

		patchDoc.ApplyTo(result.postToPatch);

		TryValidateModel(result.postToPatch);

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.PostService.SaveToPatch(result.postToPatch, result.postEntity, trackChanges: true);

		return NoContent();
	}
}
