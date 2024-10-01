using Appointments.Domain.Models;
using AutoMapper;

namespace Appointments.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, User>().ReverseMap();
			CreateMap<Client, Client>().ReverseMap();
			CreateMap<Clinic, Clinic>().ReverseMap();
			CreateMap<Appointment, Appointment>().ReverseMap();
			CreateMap<Payment, Payment>().ReverseMap();
		}
    }
}
