using Appointments.Application.MediatR.Requests.AppointmentRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AppointmentController : ControllerBase
	{
		private readonly IMediator mediatR;

		public AppointmentController(IMediator mediatR)
		{
			this.mediatR = mediatR;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("CreateAppointment")]
		public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest createAppointmentRequest)
		{
			await mediatR.Send(createAppointmentRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllAppointments")]
		public async Task<IActionResult> GetAllAppointments([FromBody] GetAllAppointmentRequest getAllAppointmentRequest)
		{
			var response = await mediatR.Send(getAllAppointmentRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteAppointmentById")]
		public async Task<IActionResult> DeleteAppointmentById([FromBody] DeleteAppointmentByIdRequest deleteAppointmentByIdRequest)
		{
			var response = await mediatR.Send(deleteAppointmentByIdRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("UpdateAppointment")]
		public async Task<IActionResult> UpdateAppointment([FromBody] UpdateAppointmentRequest updateAppointmentRequest)
		{
			var response = await mediatR.Send(updateAppointmentRequest);
			return Ok();
		}
	}
}
