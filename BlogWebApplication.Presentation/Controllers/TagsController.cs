using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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

	[HttpGet("{id:guid}")]
	public IActionResult GetTag(Guid id)
	{
		var tag = _service.TagService.GetTag(id, trackChanges: false);
		return Ok(tag);
	}
}
