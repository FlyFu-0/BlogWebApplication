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
		var posts = _service.PostService.GetAllPosts(trackChanges: false);
		return Ok(posts);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetPost(Guid id)
	{
		var post = _service.PostService.GetPost(id, trackChanges: false);
		return Ok(post);
	}
}
