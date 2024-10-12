using AutoMapper;
using BLL.DTO.AddOn;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class AddOnService : IAddOnService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddOnService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddOnDto>> GetAllAddOnsAsync()
    {
        return _mapper.Map<IEnumerable<AddOnDto>>(await _unitOfWork.AddOns.GetAllAsync());
    }

    public async Task<Dictionary<string, List<AddOnDto>>> GetAddOnsGroupedByTypeAsync()
    {
        var groupedAddOns = await _unitOfWork.AddOns.GetAddOnsGroupedByTypeAsync();
        var result = new Dictionary<string, List<AddOnDto>>();
        foreach (var k in groupedAddOns)
        {
            result[k.Key] = _mapper.Map<List<AddOnDto>>(k.Value);
        }
        return result;
    }

    public async Task AddAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var addOn = _mapper.Map<AddOn>(addOnDto);
            addOn.CreatedAt = DateTime.Now;
            await _unitOfWork.AddOns.AddAsync(addOn);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var addOn = _mapper.Map<AddOn>(addOnDto);
            await _unitOfWork.AddOns.UpdateAsync(addOn);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task DeleteAddOnAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _unitOfWork.AddOns.DeleteAsync(id);
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