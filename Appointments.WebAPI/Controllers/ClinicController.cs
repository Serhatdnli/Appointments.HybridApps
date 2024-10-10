using Appointments.Application.MediatR.Requests.ClinicRequests;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
			var response = await mediatR.Send(createClinicRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("AddRandomClinic")]
		public async Task<IActionResult> AddRandomClinic([FromBody] AddRandomClinicRequest createClinicRequest)
		{
            var response = await mediatR.Send(createClinicRequest);
			return Ok(response);
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
		[Route("GetAllClinicsByFilter")]
		public async Task<IActionResult> GetAllClinicsByFilter([FromBody] GetAllClinicsByFilterRequest getAllClinicsByFilterRequest)
		{
			var response = await mediatR.Send(getAllClinicsByFilterRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteClinicById")]
		public async Task<IActionResult> DeleteClinicById([FromBody] DeleteClinicByIdRequest deleteClinicByIdRequest)
		{
			var response = await mediatR.Send(deleteClinicByIdRequest);
			return Ok(response);
		}



		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteAllClinics")]
		public async Task<IActionResult> DeleteAllClinics([FromBody] DeleteAllClinicsRequest deleteAllClinicsRequest)
		{
			var response = await mediatR.Send(deleteAllClinicsRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("UpdateClinic")]
		public async Task<IActionResult> UpdateClinic([FromBody] UpdateClinicRequest updateClinicRequest)
		{
			var response = await mediatR.Send(updateClinicRequest);
			return Ok(response);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetClinicById")]
		public async Task<IActionResult> GetClinicById([FromBody] GetClinicByIdRequest getClinicByIdRequest)
		{
			var response = await mediatR.Send(getClinicByIdRequest);
			return Ok(response);
		}
	}
}
