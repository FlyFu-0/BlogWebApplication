using Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO.TagDtos;

namespace BlogWebApplication.Presentation.Controllers;

[Route("api/tags")]
[ApiController]
public class TagsController : ControllerBase
{
	private readonly IServiceManager _service;

	public TagsController(IServiceManager service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> GetTags()
	{
		var tags = await _service.TagService.GetAllTags(trackChanges: false);
		return Ok(tags);
	}

	[HttpGet("{id:guid}", Name = "TagById")]
	public async Task<IActionResult> GetTag(Guid id)
	{
		var tag = await _service.TagService.GetTag(id, trackChanges: false);
		return Ok(tag);
	}

	[HttpPost]
	public async Task<IActionResult> CreateTag([FromBody] TagCreationDto tag)
	{
		if (tag is null)
			return BadRequest("TagCreationDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		var createdTag = await _service.TagService.CreateTag(tag);

		return CreatedAtRoute("TagById", new { id = createdTag.Id }, createdTag);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteTag(Guid id)
	{
		await _service.TagService.DeleteTag(id, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> UpdateTag(Guid id, TagUpdateDto tag)
	{
		if (tag is null)
			return BadRequest("TagUpdateDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.TagService.UpdateTag(id, tag, trackChanges: true);
		return NoContent();
	}
}
