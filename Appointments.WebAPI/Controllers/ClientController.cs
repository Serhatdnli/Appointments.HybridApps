using Appointments.Application.MediatR.Requests.ClientRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
			var response = await mediatR.Send(createClientRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("AddRandomClient")]
		public async Task<IActionResult> AddRandomClient([FromBody] AddRandomClientRequest createClientRequest)
		{
			var response = await mediatR.Send(createClientRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllClients")]
		public async Task<IActionResult> GetAllClients([FromBody] GetAllClientsRequest getAllClientsRequest)
		{
			var response = await mediatR.Send(getAllClientsRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllClientsByFilter")]
		public async Task<IActionResult> GetAllClientsByFilter([FromBody] GetAllClientsByFilterRequest getAllClientsByFilterRequest)
		{
			var response = await mediatR.Send(getAllClientsByFilterRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteClientById")]
		public async Task<IActionResult> DeleteClientById([FromBody] DeleteClientByIdRequest deleteClientByIdRequest)
		{
			var response = await mediatR.Send(deleteClientByIdRequest);
			return Ok(response);
		}



		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteAllClients")]
		public async Task<IActionResult> DeleteAllClients([FromBody] DeleteAllClientsRequest deleteAllClientsRequest)
		{
			var response = await mediatR.Send(deleteAllClientsRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("UpdateClient")]
		public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest updateClientRequest)
		{
			var response = await mediatR.Send(updateClientRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetClientById")]
		public async Task<IActionResult> GetClientById([FromBody] GetClientByIdRequest getClientByIdRequest)
		{
			var response = await mediatR.Send(getClientByIdRequest);
			return Ok(response);
		}
	}
}
