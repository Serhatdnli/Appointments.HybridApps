using Appointments.Domain.Models;
using AutoMapper;

namespace Appointments.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, User>().ReverseMap();
        }
    }
}
