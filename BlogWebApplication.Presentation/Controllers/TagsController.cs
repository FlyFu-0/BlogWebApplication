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
	public IActionResult GetTags()
	{
		var tags = _service.TagService.GetAllTags(trackChanges: false);
		return Ok(tags);
	}

	[HttpGet("{id:guid}", Name = "TagById")]
	public IActionResult GetTag(Guid id)
	{
		var tag = _service.TagService.GetTag(id, trackChanges: false);
		return Ok(tag);
	}

	[HttpPost]
	public IActionResult CreateTag([FromBody] TagCreationDto tag)
	{
		if (tag is null)
			return BadRequest("TagCreationDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		var createdTag = _service.TagService.CreateTag(tag);

		return CreatedAtRoute("TagById", new { id = createdTag.Id }, createdTag);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteTag(Guid id)
	{
		_service.TagService.DeleteTag(id, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpdateTag(Guid id, TagUpdateDto tag)
	{
		if (tag is null)
			return BadRequest("TagUpdateDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		_service.TagService.UpdateTag(id, tag, trackChanges: true);
		return NoContent();
	}
}
