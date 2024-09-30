using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO.LikeDtos;

namespace BlogWebApplication.Presentation.Controllers;

[Route("api/posts/{postId}/likes")]
[ApiController]
public class LikesControllers : ControllerBase
{
	private IServiceManager _services;

	public LikesControllers(IServiceManager services)
	{
		_services = services;
	}

	[HttpPost]
	public IActionResult CreateLike(Guid postId, bool trackChanges)
	{
		var uid = "1";

		var createdLike = _services.LikeService.CreateLike(postId, uid, trackChanges: false);
		return Created(string.Empty, createdLike);
	}
}
