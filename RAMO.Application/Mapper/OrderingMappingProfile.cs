using AutoMapper;
using RAMO.Application.Commands;
using RAMO.Application.Response;
using RAMO.Core.Entities;

namespace RAMO.Application.Mapper
{
    public class RAMOMappingProfile : Profile
    {
        public RAMOMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, EditCustomerCommand>().ReverseMap();
        }
    }
}
