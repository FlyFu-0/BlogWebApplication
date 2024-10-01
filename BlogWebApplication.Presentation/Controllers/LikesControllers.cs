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
	public IActionResult ToggleLike(Guid postId)
	{
		var userId = "1";

		var like = _services.LikeService.ToggleLike(postId, userId, trackChanges: false);
		return Created(string.Empty, like);
	}

	//[HttpPost]
	//public IActionResult CreateLike(Guid postId)
	//{
	//	var uid = "1";

	//	var createdLike = _services.LikeService.CreateLike(postId, uid, trackChanges: false);
	//	return Created(string.Empty, createdLike);
	//}

	//[HttpDelete]
	//public IActionResult DeleteLike(Guid postId)
	//{
	//	var userId = "1";

	//	_services.LikeService.DeleteLike(postId, userId, trackChanges: false);

	//	return NoContent();
	//}
}
