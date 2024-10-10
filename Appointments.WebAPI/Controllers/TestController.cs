using Appointments.Application.IRepositories;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointments.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TestController : ControllerBase
	{
		private readonly IMediator mediatR;
		private readonly IAppointmentRepository appointmentRepository;
		private readonly IClientRepository clientRepository;
		private readonly IClinicRepository clinicRepository;
		private readonly IPaymentRepository paymentRepository;
		private readonly IUserRepository userRepository;

		public TestController(IMediator mediatR, IAppointmentRepository appointmentRepository, IClientRepository clientRepository, IClinicRepository clinicRepository, IPaymentRepository paymentRepository, IUserRepository userRepository)
		{
			this.mediatR = mediatR;
			this.appointmentRepository = appointmentRepository;
			this.clientRepository = clientRepository;
			this.clinicRepository = clinicRepository;
			this.paymentRepository = paymentRepository;
			this.userRepository = userRepository;
		}

		[HttpGet]
		[AllowAnonymous]
		[Route("CheckAppointment")]
		public async Task<IActionResult> CheckAppointment()
		{
			var clinic = await clinicRepository.GetQueryable().FirstOrDefaultAsync();
			var doctor = await userRepository.GetQueryable(x => x.Role == Domain.Enums.UserRoleType.Doctor).FirstOrDefaultAsync();
			var client = await clientRepository.GetQueryable().FirstOrDefaultAsync();

			Appointment appointment = new Appointment
			{
				ClientId = client.Id,
				DoctorId = doctor.Id,
				ClinicId = clinic.Id,
				Notes = "ilk notum",
				IsPayed = false,
				CreateDate = DateTime.Now,
				Price = 1000,
				AppointmentTime = DateTime.Now,
				AppointmentFinishTime = DateTime.Now.AddMinutes(45)

			};

			var response = await appointmentRepository.AddAsync(appointment);
			await appointmentRepository.CompleteAsync();
			return Ok(response);
		}


		[HttpGet]
		[AllowAnonymous]
		[Route("AddInitData")]
		public async Task<IActionResult> AddInitData()
		{
			Client client = new Client
			{
				Id = Guid.NewGuid(),
				Name = "Muhammet",
				Surname = "boyraz",
				CreateDate = DateTime.Now,
				Email = "boyo@gmail.com",
				PhoneNumber = "05425266854",
				TcId = "52451486954"
			};

			await clientRepository.AddAsync(client);
			await clientRepository.CompleteAsync();

			Clinic clinic = new Clinic
			{
				CreateDate = DateTime.Now,
				Id = Guid.NewGuid(),
				Name = "Fizyoterapi"
			};

			await clinicRepository.AddAsync(clinic);
			await clinicRepository.CompleteAsync();


			User doctor = await userRepository.GetQueryable().FirstOrDefaultAsync();
			Appointment appointment = new Appointment
			{
				ClientId = client.Id,
				DoctorId = doctor.Id,
				ClinicId = clinic.Id,
				Notes = "merhaba",
				IsPayed = false,
				Id = Guid.NewGuid(),
				CreateDate = DateTime.Now,
				Price = 1000,
				AppointmentTime = DateTime.Now,
			};

			await appointmentRepository.AddAsync(appointment);
			await appointmentRepository.CompleteAsync();

			Payment payment = new Payment
			{
				AppointmentId = appointment.Id,
				CreateDate = DateTime.Now,
				Id = Guid.NewGuid(),
				PaymentType = Domain.Enums.PaymentType.Credit_Card,
				Price = 400
			};

			await paymentRepository.AddAsync(payment);
			await paymentRepository.CompleteAsync();


			return Ok();
		}

		[HttpGet]
		[AllowAnonymous]
		[Route("GetAppointments")]
		public async Task<IActionResult> GetAppointments()
		{
			var app = await appointmentRepository.GetQueryable().Include(x => x.Payments).Include(x => x.Client).Include(x => x.Doctor).Include(x => x.Clinic).FirstOrDefaultAsync();

			return Ok(app);
		}
	}
}
