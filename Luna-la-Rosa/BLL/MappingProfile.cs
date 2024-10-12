using AutoMapper;
using BLL.DTO.AddOn;
using DAL.Entities;

namespace BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddOn, AddOnDto>().ReverseMap(); 
    }
}