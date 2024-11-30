using AutoMapper;
using BLL.DTO.Order;
using DAL.Entities;

namespace BLL.Helpers.Mapping;

public static class DeliveryAddressConverter
{
    public class DeliveryCityResolver : IValueResolver<Order, OrderDto, string>
    {
        public string Resolve(Order source, OrderDto destination, string destMember, ResolutionContext context)
        {
            var parts = SplitAddress(source.DeliveryAddress);
            return parts.city;
        }
    }

    public class DeliveryStreetResolver : IValueResolver<Order, OrderDto, string>
    {
        public string Resolve(Order source, OrderDto destination, string destMember, ResolutionContext context)
        {
            var parts = SplitAddress(source.DeliveryAddress);
            return parts.street;
        }
    }

    public class DeliveryBuildingResolver : IValueResolver<Order, OrderDto, string>
    {
        public string Resolve(Order source, OrderDto destination, string destMember, ResolutionContext context)
        {
            var parts = SplitAddress(source.DeliveryAddress);
            return parts.building;
        }
    }

    private static (string city, string street, string building) SplitAddress(string? address)
    {
        if (string.IsNullOrEmpty(address))
            return (string.Empty, string.Empty, string.Empty);

        var parts = address.Split(", ", StringSplitOptions.None);
        return (
            parts.ElementAtOrDefault(0) ?? string.Empty,
            parts.ElementAtOrDefault(1) ?? string.Empty,
            parts.ElementAtOrDefault(2) ?? string.Empty
        );
    }
}