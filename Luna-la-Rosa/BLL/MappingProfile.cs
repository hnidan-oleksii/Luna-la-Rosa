using AutoMapper;
using BLL.DTO.AddOn;
using BLL.DTO.Bouquet;
using BLL.DTO.BouquetCategory;
using BLL.DTO.BouquetCategoryBouquet;
using BLL.DTO.BouquetFlower;
using BLL.DTO.CustomBouquet;
using BLL.DTO.Flower;
using BLL.DTO.ItemAddOn;
using BLL.DTO.Order;
using BLL.DTO.ShoppingCart;
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
        CreateMap<Bouquet, BouquetDto>()
            .ForMember(dto => dto.Flowers, opt => opt.MapFrom(entity => entity.BouquetFlowers))
            .ForMember(dto => dto.Categories, opt => opt.MapFrom(entity => entity.BouquetCategories))
            .ForMember(dto => dto.AddOns, opt => opt.MapFrom(entity => entity.BouquetAddOns))
            .ReverseMap();
        CreateMap<CreateBouquetDto, Bouquet>();
        CreateMap<BouquetCategory, BouquetCategoryDto>().ReverseMap();
        CreateMap<BouquetCategoryBouquet, BouquetCategoryBouquetDto>().ReverseMap();
        CreateMap<BouquetFlower, BouquetFlowerDto>()
            .ForMember(dto => dto.Flower, opt => opt.MapFrom(entity => entity.Flower))
            .ReverseMap();
        CreateMap<BouquetAddOn, ItemAddOnDto>()
            .ForMember(dto => dto.AddOn, opt => opt.MapFrom(entity => entity.AddOn));

        // CustomBouquets
        CreateMap<CustomBouquet, CustomBouquetDto>()
            .ForMember(dto => dto.CustomBouquetFlowers, opt => opt.MapFrom(entity => entity.CustomBouquetFlowers))
            .ForMember(dto => dto.CustomBouquetAddOns, opt => opt.MapFrom(entity => entity.CustomBouquetAddOns))
            .ReverseMap();
        CreateMap<CreateCustomBouquetDto, CustomBouquet>()
            .ForMember(dto => dto.CustomBouquetFlowers, opt => opt.Ignore())
            .ForMember(dto => dto.CustomBouquetAddOns, opt => opt.Ignore());
        CreateMap<BouquetFlowerDto, CustomBouquetFlower>()
            .ForMember(entity => entity.CustomBouquetId, opt => opt.MapFrom(dto => dto.BouquetId))
            .ReverseMap();
        CreateMap<ItemAddOnDto, BouquetAddOn>()
            .ForMember(entity => entity.CustomBouquetId,
                opt => opt.MapFrom((_, _, _, context) => context.Items["CustomBouquetId"]));

        // Flowers
        CreateMap<Flower, FlowerDto>().ReverseMap();
        CreateMap<CreateFlowerDto, Flower>();

        // Shopping cart
        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dto => dto.CartItems, opt => opt.MapFrom(entity => entity.CartItems))
            .ReverseMap();
        CreateMap<CartItem, CartItemDto>()
            .ForMember(dto => dto.AddOns, opt => opt.MapFrom(entity => entity.AddOns));

        // Orders
        CreateMap<Order, OrderDto>()
            .ForMember(dto => dto.DeliveryCity, opt => opt.MapFrom<DeliveryAddressConverter.DeliveryCityResolver>())
            .ForMember(dto => dto.DeliveryStreet, opt => opt.MapFrom<DeliveryAddressConverter.DeliveryStreetResolver>())
            .ForMember(dto => dto.DeliveryBuilding,
                opt => opt.MapFrom<DeliveryAddressConverter.DeliveryBuildingResolver>())
            .ReverseMap()
            .ForMember(entity => entity.DeliveryAddress,
                opt => opt.MapFrom(dto =>
                    string.Join(", ", dto.DeliveryCity, dto.DeliveryStreet, dto.DeliveryBuilding)));
        CreateMap<OrderBouquet, OrderBouquetDto>()
            .ForMember(dto => dto.AddOns, opt => opt.MapFrom(entity => entity.AddOns))
            .ReverseMap()
            .ForMember(entity => entity.AddOns, opt => opt.Ignore());
        CreateMap<OrderAddOn, ItemAddOnDto>()
            .ForMember(dto => dto.BouquetId, opt => opt.MapFrom(entity => entity.OrderBouquetId))
            .ReverseMap();
    }
}