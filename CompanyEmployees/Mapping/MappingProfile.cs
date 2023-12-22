using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Diagnostics;

namespace CompanyEmployees.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Comnata, ComnataDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Human, HumanDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<ComnataForCreationDto, Comnata>();
            CreateMap<HumanForCreationDto, Human>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<HumanForUpdateDto, Human>().ReverseMap();
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<ComnataForUpdateDto, Comnata>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}

