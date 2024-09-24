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
        public async Task<IActionResult> GetAllUsers([FromBody] GetAllUserRequest getAllUserRequest)
        {
            var response = await mediatR.Send(getAllUserRequest);
            return Ok(response);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("DeleteUserWithTcId")]
        public async Task<IActionResult> DeleteUserWithTcId([FromBody] DeleteUserWithTcIdRequest deleteUserWithTcIdRequest)
        {
            var response = await mediatR.Send(deleteUserWithTcIdRequest);
            return Ok();
        }

		[HttpDelete]
		[AllowAnonymous]
		[Route("DeleteUserWithUserId")]
		public async Task<IActionResult> DeleteUserWithUserId([FromBody] DeleteUserWithUserIdRequest deleteUserWithUserIdRequest)
		{
			var response = await mediatR.Send(deleteUserWithUserIdRequest);
			return Ok();
		}

        [HttpDelete]
        [AllowAnonymous]
        [Route("DeleteAllUsers")]
        public async Task<IActionResult> DeleteAllUsers([FromBody] DeleteAllUserRequest deleteAllUserRequest)
        {
            var response = await mediatR.Send(deleteAllUserRequest);
            return Ok();
        }

		[HttpPut]
        [AllowAnonymous]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            var response = await mediatR.Send(updateUserRequest);
            return Ok();
        }

        
	}
}
