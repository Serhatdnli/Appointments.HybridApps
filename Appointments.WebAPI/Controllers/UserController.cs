using Appointments.Application.MediatR.Requests.UserRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserController : ControllerBase
	{
		private readonly IMediator mediatR;

		public UserController(IMediator mediatR)
		{
			this.mediatR = mediatR;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("CreateUser")]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
		{
			await mediatR.Send(createUserRequest);
			return Ok();
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("AddRandomUser")]
		public async Task<IActionResult> AddRandomUser([FromBody] AddRandomUserRequest createUserRequest)
		{
			await mediatR.Send(createUserRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllUsers")]
		public async Task<IActionResult> GetAllUsers([FromBody] GetAllUsersRequest getAllUsersRequest)
		{
			var response = await mediatR.Send(getAllUsersRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllUsersByFilter")]
		public async Task<IActionResult> GetAllUsersByFilter([FromBody] GetAllUsersByFilterRequest getAllUsersByFilterRequest)
		{
            Console.WriteLine("api isteðine girdimm");
            var response = await mediatR.Send(getAllUsersByFilterRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteUserById")]
		public async Task<IActionResult> DeleteUserById([FromBody] DeleteUserByIdRequest deleteUserByIdRequest)
		{
			var response = await mediatR.Send(deleteUserByIdRequest);
			return Ok();
		}



		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteAllUsers")]
		public async Task<IActionResult> DeleteAllUsers([FromBody] DeleteAllUsersRequest deleteAllUsersRequest)
		{
			var response = await mediatR.Send(deleteAllUsersRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("UpdateUser")]
		public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
		{
			var response = await mediatR.Send(updateUserRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetUserById")]
		public async Task<IActionResult> GetUserById([FromBody] GetUserByIdRequest getUserByIdRequest)
		{
			var response = await mediatR.Send(getUserByIdRequest);
			return Ok();
		}
	}
}
