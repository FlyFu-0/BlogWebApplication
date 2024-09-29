using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace BlogWebApplication.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
	private readonly IServiceManager _service;

	public PostController(IServiceManager service)
	{
		_service = service;
	}

	[HttpGet]
	public IActionResult GetPosts()
	{
		try
		{
			var posts = _service.PostService.GetAllPosts(trackChanges: false);
			return Ok(posts);
		}
		catch
		{
			return StatusCode(500, "Internal Server Error");
		}
	}
}
