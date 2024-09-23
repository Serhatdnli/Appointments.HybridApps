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
        public async Task<IActionResult> GetAllUsers([FromBody] GetAllUserRequest createUserRequest)
        {
            var response = await mediatR.Send(createUserRequest);
            return Ok(response);
        }
    }
}
