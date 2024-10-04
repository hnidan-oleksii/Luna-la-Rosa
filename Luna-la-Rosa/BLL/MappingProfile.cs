using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddOn, AddOnDto>().ReverseMap(); 
    }
}