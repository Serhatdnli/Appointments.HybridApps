﻿using Appointments.Application.MediatR.Requests.AppointmentRequests;
using Appointments.Application.MediatR.Requests.ClientRequests;
using Appointments.Application.MediatR.Requests.ClinicRequests;
using Appointments.Application.MediatR.Requests.PaymentRequests;
using Appointments.Application.MediatR.Requests.UserRequests;
using Appointments.Domain.Dtos.AppointmentDtos;
using Appointments.Domain.Models;
using AutoMapper;

namespace Appointments.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			CreateMap<Appointment, GetAppointmentDto>().ReverseMap();
			CreateMap<Appointment, UpdateAppointmentDto>().ReverseMap();
			CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
			CreateMap<GetAppointmentDto, UpdateAppointmentDto>().ReverseMap();


			CreateMap<User, User>().ReverseMap();
			CreateMap<Client, Client>().ReverseMap();
			CreateMap<Clinic, Clinic>().ReverseMap();
			CreateMap<Payment, Payment>().ReverseMap();

		
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<Client,ClientDto>().ReverseMap();
			CreateMap<Clinic,ClinicDto>().ReverseMap();
			CreateMap<Payment,PaymentDto>().ReverseMap();

		
			CreateMap<User, CreateUserRequest>().ReverseMap();
			CreateMap<Client, CreateClientRequest>().ReverseMap();
			CreateMap<Clinic, CreateClinicRequest>().ReverseMap();
			CreateMap<Payment, CreatePaymentRequest>().ReverseMap();
			


		}
	}
}
