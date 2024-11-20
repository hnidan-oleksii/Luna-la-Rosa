using AutoMapper;
using BLL.DTO.Flower;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers.Params;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class FlowerService : IFlowerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FlowerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FlowerDto>> GetAllFlowersAsync(FlowerParams flowerParams)
    {
        var searchFields = new List<string> { "Name" };
        var flowers = await _unitOfWork.Flowers.GetAllFlowersAsync(flowerParams, searchFields);

        return _mapper.Map<IEnumerable<FlowerDto>>(flowers);
    }

    public async Task<Dictionary<string, List<FlowerDto>>> GetFlowersGroupedByTypeAsync()
    {
        var groupedFlowers = await _unitOfWork.Flowers.GetFlowersGroupedByTypeAsync();
        return _mapper.Map<Dictionary<string, List<FlowerDto>>>(groupedFlowers);
    }

    public async Task<FlowerDto> GetFlowerByIdAsync(int id)
    {
        var flower = await _unitOfWork.Flowers.GetByIdAsync(id);
        return _mapper.Map<FlowerDto>(flower);
    }

    public async Task<int> AddFlowerAsync(CreateFlowerDto flowerDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var flower = _mapper.Map<Flower>(flowerDto);
            flower.CreatedAt = DateTime.UtcNow.ToUniversalTime();

            await _unitOfWork.Flowers.AddAsync(flower);

            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return flower.Id;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateFlowerAsync(FlowerDto flowerDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var flower = _mapper.Map<Flower>(flowerDto);
            flower.UpdatedAt = DateTime.Now.ToUniversalTime();

            await _unitOfWork.Flowers.UpdateAsync(flower);

            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task DeleteFlowerAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _unitOfWork.Flowers.DeleteAsync(id);
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