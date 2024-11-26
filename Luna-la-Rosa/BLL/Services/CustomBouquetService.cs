using AutoMapper;
using BLL.DTO.CustomBouquet;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class CustomBouquetService : ICustomBouquetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomBouquetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

<<<<<<< HEAD
    public async Task<int> AddCustomBouquetAsync(CreateCustomBouquetDto customBouquetDto,
=======
    public async Task<CustomBouquetDto> GetCustomBouquetByIdAsync(int id)
    {
        var customBouquet = await _unitOfWork.CustomBouquets.GetByIdAsync(id);
        return _mapper.Map<CustomBouquetDto>(customBouquet, opts => opts.Items["CustomBouquetId"] = customBouquet.Id);
    }

    public async Task<ShoppingCartDto> AddCustomBouquetAsync(CreateCustomBouquetDto customBouquetDto,
>>>>>>> 5cddf92 (fixup for custom bouquet service)
        CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var customBouquet = _mapper.Map<CustomBouquet>(customBouquetDto);
            await _unitOfWork.CustomBouquets.AddAsync(customBouquet);

            foreach (var flower in customBouquetDto.CustomBouquetFlowers)
                flower.BouquetId = customBouquet.Id;
            foreach (var addOn in customBouquetDto.CustomBouquetAddOns)
                addOn.BouquetId = customBouquet.Id;

            customBouquet.CustomBouquetFlowers =
                _mapper.Map<IEnumerable<CustomBouquetFlower>>(customBouquetDto.CustomBouquetFlowers,
                    opts => opts.Items["CustomBouquetId"] = customBouquet.Id);
            customBouquet.CustomBouquetAddOns =
                _mapper.Map<IEnumerable<BouquetAddOn>>(customBouquetDto.CustomBouquetAddOns,
                    opts => opts.Items["CustomBouquetId"] = customBouquet.Id);
            await _unitOfWork.CustomBouquets.UpdateAsync(customBouquet);

            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return customBouquet.Id;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateCustomBouquetAsync(CustomBouquetDto customBouquetDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var customBouquet = _mapper.Map<CustomBouquet>(customBouquetDto,
                opt => opt.Items["CustomBouquetId"] = customBouquetDto.Id);
            customBouquet.TotalPrice =
                CalculateTotalPrice(customBouquet.CustomBouquetFlowers, customBouquet.CustomBouquetAddOns);
            await _unitOfWork.CustomBouquets.UpdateAsync(customBouquet);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    private static decimal CalculateTotalPrice(IEnumerable<CustomBouquetFlower> flowers,
        IEnumerable<BouquetAddOn> addOns)
    {
        var itemAddOnDtos = addOns.ToList();

        var totalPrice = flowers.Sum(f => f.Quantity * f.Flower.Price);
        if (itemAddOnDtos.Count != 0)
            totalPrice += itemAddOnDtos.Sum(ao => ao.Quantity * ao.AddOn.Price);

        return totalPrice;
    }
}