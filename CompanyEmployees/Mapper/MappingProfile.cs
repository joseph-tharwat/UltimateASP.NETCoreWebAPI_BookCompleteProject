using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace CompanyEmployees.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Company, CompanyDto>()
                .ForMember(dst => dst.FullAddress,
                    option=> option.MapFrom(src=> src.Address + ", " + src.Country));

            CreateMap<CompanyDto, Company>()
                .ForMember(dst => dst.Address,
                    option => option.MapFrom(src => src.FullAddress.Split(new[] { "," }, StringSplitOptions.None)[0]))
                .ForMember(dst=>dst.Country,
                    option => option.MapFrom(src => src.FullAddress.Split(new[] { "," }, StringSplitOptions.None)[1]));


            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<Company, CompanyForCreationDto>();
        }

    }
}
