using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
	public async Task<IActionResult> ToggleLike(Guid postId)
	{
		var userId = "1";

		var like = await _services.LikeService.ToggleLike(postId, userId, trackChanges: false);
		return Created(string.Empty, like);
	}
}
