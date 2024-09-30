using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace BlogWebApplication.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UsersControllers : ControllerBase
{
	private readonly IServiceManager _service;

	public UsersControllers(IServiceManager service)
	{
		_service = service;
	}

	[HttpGet]
	public IActionResult GetUsers()
	{
		var users = _service.UserService.GetAllUsers(trackChanges: false);

		return Ok(users);
	}
}
