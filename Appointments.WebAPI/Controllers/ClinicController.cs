using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ClinicController : ControllerBase
	{
		private readonly IMediator mediatR;

		public ClinicController(IMediator mediatR)
		{
			this.mediatR = mediatR;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("CreateClinic")]
		public async Task<IActionResult> CreateClinic([FromBody] CreateClinicRequest createClinicRequest)
		{
			await mediatR.Send(createClinicRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllClinics")]
		public async Task<IActionResult> GetAllClinics([FromBody] GetAllClinicsRequest getAllClinicsRequest)
		{
			var response = await mediatR.Send(getAllClinicsRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteClinicById")]
		public async Task<IActionResult> DeleteClinicById([FromBody] DeleteClinicByIdRequest deleteClinicByIdRequest)
		{
			var response = await mediatR.Send(deleteClinicByIdRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("UpdateClinic")]
		public async Task<IActionResult> UpdateClinic([FromBody] UpdateClinicRequest updateClinicRequest)
		{
			var response = await mediatR.Send(updateClinicRequest);
			return Ok();
		}
	}
}
