using AutoMapper;
using BLL.DTO.Bouquet;
using BLL.DTO.BouquetCategoryBouquet;
using BLL.DTO.ItemAddOn;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class BouquetService : IBouquetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BouquetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BouquetDto> GetBouquetByIdAsync(int id)
    {
        return _mapper.Map<BouquetDto>(await _unitOfWork.Bouquets.GetByIdAsync(id));
    }

    public PagedList<BouquetDto> GetBouquets(BouquetParams parameters)
    {
        var searchFields = new List<string> { "Name" };
        var bouquets = _unitOfWork.Bouquets.GetBouquets(parameters, searchFields);
        return _mapper.Map<PagedList<BouquetDto>>(bouquets);
    }

    public async Task AddBouquetAsync(CreateBouquetDto bouquetDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var bouquet = _mapper.Map<Bouquet>(bouquetDto);

            bouquet.CreatedAt = DateTime.Now.ToUniversalTime();
            bouquet.Price = bouquetDto.Flowers.Sum(f => f.Quantity * f.Flower.Price);
            if (bouquetDto.AddOns != null)
            {
                bouquet.Price += bouquetDto.AddOns.Sum(ao => ao.Quantity * ao.AddOn.Price);
            }

            await _unitOfWork.Bouquets.AddAsync(bouquet);

            foreach (var flower in bouquetDto.Flowers)
                flower.BouquetId = bouquet.Id;
            foreach (var addOn in bouquetDto.AddOns ?? Enumerable.Empty<ItemAddOnDto>())
                addOn.BouquetId = bouquet.Id;
            foreach (var category in bouquetDto.Categories ?? Enumerable.Empty<BouquetCategoryBouquetDto>())
                category.BouquetId = bouquet.Id;

            bouquet.BouquetCategories = _mapper.Map<ICollection<BouquetCategoryBouquet>>(bouquetDto.Categories);
            bouquet.BouquetAddOns = _mapper.Map<ICollection<BouquetAddOn>>(bouquetDto.AddOns);
            bouquet.BouquetFlowers = _mapper.Map<ICollection<BouquetFlower>>(bouquetDto.Flowers);
            await _unitOfWork.Bouquets.UpdateAsync(bouquet);

            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateBouquetAsync(BouquetDto bouquetDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var bouquet = _mapper.Map<Bouquet>(bouquetDto);
            bouquet.UpdatedAt = DateTime.Now.ToUniversalTime();
            await _unitOfWork.Bouquets.UpdateAsync(bouquet);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task DeleteBouquetAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _unitOfWork.Bouquets.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}