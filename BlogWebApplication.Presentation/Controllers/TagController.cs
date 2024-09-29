using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace BlogWebApplication.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
	private readonly IServiceManager _service;

	public TagController(IServiceManager service)
	{
		_service = service;
	}

	[HttpGet]
	public IActionResult GetTags()
	{
		try
		{
			var tags = _service.TagService.GetAllTags(trackChanges: false);
			return Ok(tags);
		}
		catch
		{
			return StatusCode(500, "Internal Server Error");
		}
	}
}
