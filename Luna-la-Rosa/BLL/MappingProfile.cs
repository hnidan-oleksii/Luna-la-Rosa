using AutoMapper;
using BLL.DTO.AddOn;
using BLL.DTO.Bouquet;
using BLL.DTO.BouquetCategory;
using BLL.DTO.BouquetCategoryBouquet;
using BLL.DTO.BouquetFlower;
using BLL.DTO.Flower;
using BLL.Helpers.Mapping;
using DAL.Entities;
using DAL.Helpers;

namespace BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(PagedList<>), typeof(PagedList<>))
            .ConvertUsing(typeof(PagedListConverter<,>));
        //AddOn
        CreateMap<AddOn, AddOnDto>().ReverseMap();
        CreateMap<CreateAddOnDto, AddOn>().ReverseMap();
        // Bouquets
        CreateMap<Bouquet, BouquetDto>();
        CreateMap<CreateBouquetDto, Bouquet>();
        CreateMap<BouquetCategory, BouquetCategoryDto>().ReverseMap();
        CreateMap<BouquetCategoryBouquet, BouquetCategoryBouquetDto>().ReverseMap();
        CreateMap<BouquetFlower, BouquetFlowerDto>().ReverseMap();
        // Flowers
        CreateMap<Flower, FlowerDto>().ReverseMap();
    }
}