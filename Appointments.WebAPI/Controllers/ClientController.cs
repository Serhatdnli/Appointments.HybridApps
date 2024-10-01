using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ClientController : ControllerBase
	{
		private readonly IMediator mediatR;

		public ClientController(IMediator mediatR)
		{
			this.mediatR = mediatR;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("CreateClient")]
		public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest createClientRequest)
		{
			await mediatR.Send(createClientRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllClients")]
		public async Task<IActionResult> GetAllClients([FromBody] GetAllClientRequest getAllClientRequest)
		{
			var response = await mediatR.Send(getAllClientRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteClientById")]
		public async Task<IActionResult> DeleteClientById([FromBody] DeleteClientByIdRequest deleteClientByIdRequest)
		{
			var response = await mediatR.Send(deleteClientByIdRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("UpdateClient")]
		public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest updateClientRequest)
		{
			var response = await mediatR.Send(updateClientRequest);
			return Ok();
		}
	}
}
