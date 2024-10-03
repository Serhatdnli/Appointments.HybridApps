using Appointments.Application.MediatR.Requests.PaymentRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PaymentController : ControllerBase
	{
		private readonly IMediator mediatR;

		public PaymentController(IMediator mediatR)
		{
			this.mediatR = mediatR;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("CreatePayment")]
		public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest createPaymentRequest)
		{
			await mediatR.Send(createPaymentRequest);
			return Ok();
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("AddRandomPayment")]
		public async Task<IActionResult> AddRandomPayment([FromBody] AddRandomPaymentRequest createPaymentRequest)
		{
			await mediatR.Send(createPaymentRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllPayments")]
		public async Task<IActionResult> GetAllPayments([FromBody] GetAllPaymentsRequest getAllPaymentsRequest)
		{
			var response = await mediatR.Send(getAllPaymentsRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("GetAllPaymentsByFilter")]
		public async Task<IActionResult> GetAllPaymentsByFilter([FromBody] GetAllPaymentsByFilterRequest getAllPaymentsByFilterRequest)
		{
			var response = await mediatR.Send(getAllPaymentsByFilterRequest);
			return Ok(response);
		}


		[HttpPost]
		[AllowAnonymous]
		[Route("DeletePaymentById")]
		public async Task<IActionResult> DeletePaymentById([FromBody] DeletePaymentByIdRequest deletePaymentByIdRequest)
		{
			var response = await mediatR.Send(deletePaymentByIdRequest);
			return Ok();
		}



		[HttpPost]
		[AllowAnonymous]
		[Route("DeleteAllPayments")]
		public async Task<IActionResult> DeleteAllPayments([FromBody] DeleteAllPaymentsRequest deleteAllPaymentsRequest)
		{
			var response = await mediatR.Send(deleteAllPaymentsRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("UpdatePayment")]
		public async Task<IActionResult> UpdatePayment([FromBody] UpdatePaymentRequest updatePaymentRequest)
		{
			var response = await mediatR.Send(updatePaymentRequest);
			return Ok();
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("GetPaymentById")]
		public async Task<IActionResult> GetPaymentById([FromBody] GetPaymentByIdRequest getPaymentByIdRequest)
		{
			var response = await mediatR.Send(getPaymentByIdRequest);
			return Ok();
		}
	}
}
