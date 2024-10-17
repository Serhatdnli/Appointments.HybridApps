﻿using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
namespace Appointments.Application.MediatR.Responses.AppointmentResponses
{
    public class GetAllAppointmentsResponse : MediatRBaseResponse
	{
		public List<GetAppointmentDto> Appointments { get; set; }
		public int Count { get; set; }
	}

}