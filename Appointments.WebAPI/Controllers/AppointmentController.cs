using Appointments.Application.MediatR.Requests.AppointmentRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
		[Route("AddRandomAppointment")]
		public async Task<IActionResult> AddRandomAppointment([FromBody] AddRandomAppointmentRequest createAppointmentRequest)
		{
			await mediatR.Send(createAppointmentRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllAppointments")]
		public async Task<IActionResult> GetAllAppointments([FromBody] GetAllAppointmentsRequest getAllAppointmentsRequest)
		{
			var response = await mediatR.Send(getAllAppointmentsRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllAppointmentsByFilter")]
		public async Task<IActionResult> GetAllAppointmentsByFilter([FromBody] GetAllAppointmentsByFilterRequest getAllAppointmentsByFilterRequest)
		{
			var response = await mediatR.Send(getAllAppointmentsByFilterRequest);
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
		[Route("DeleteAllAppointments")]
		public async Task<IActionResult> DeleteAllAppointments([FromBody] DeleteAllAppointmentsRequest deleteAllAppointmentsRequest)
		{
			var response = await mediatR.Send(deleteAllAppointmentsRequest);
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

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAppointmentById")]
		public async Task<IActionResult> GetAppointmentById([FromBody] GetAppointmentByIdRequest getAppointmentByIdRequest)
		{
			var response = await mediatR.Send(getAppointmentByIdRequest);
			return Ok();
		}
	}
}
