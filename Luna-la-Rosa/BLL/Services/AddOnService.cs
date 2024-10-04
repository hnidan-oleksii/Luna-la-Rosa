using AutoMapper;
using BLL.DTO;
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

    public async Task<Dictionary<string, List<AddOnDto>>> GetAddOnsGroupedByTypeAsync()
    {
        var groupedAddOns = await _unitOfWork.AddOnRepository.GetAddOnsGroupedByTypeAsync();
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
            await _unitOfWork.AddOnRepository.AddAsync(addOn);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw new ApplicationException("An error occurred while trying to add an add-on.", ex);
        }
    }

    public async Task UpdateAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var existingAddOn = await _unitOfWork.AddOnRepository.GetByIdAsync(addOnDto.Id);
            if (existingAddOn == null)
            {
                throw new KeyNotFoundException($"AddOn with ID {addOnDto.Id} not found.");
            }

            var addOn = _mapper.Map<AddOn>(addOnDto);
            await _unitOfWork.AddOnRepository.UpdateAsync(addOn);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (KeyNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw new ApplicationException("An error occurred while trying to update an add-on.", ex);
        }
    }

    public async Task DeleteAddOnAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var addOn = await _unitOfWork.AddOnRepository.GetByIdAsync(id);
            if (addOn == null)
            {
                throw new KeyNotFoundException($"AddOn with ID {id} not found.");
            }

            await _unitOfWork.AddOnRepository.DeleteAsync(addOn);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (KeyNotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw new ApplicationException("An error occurred while trying to delete an add-on.", ex);
        }
    }
}