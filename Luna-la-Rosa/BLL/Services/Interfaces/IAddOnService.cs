using BLL.DTO.AddOn;
using DAL.Helpers;

namespace BLL.Services.Interfaces;

public interface IAddOnService
{
    Task<IEnumerable<AddOnDto>> GetAllAddOnsAsync(AddOnParams addOnParams);
    Task<Dictionary<string, List<AddOnDto>>> GetAddOnsGroupedByTypeAsync();
    Task<AddOnDto> GetAddOnByIdAsync(int id);
    Task<int> AddAddOnAsync(CreateAddOnDto addOnDto, CancellationToken cancellationToken);
    Task UpdateAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken);
    Task DeleteAddOnAsync(int id, CancellationToken cancellationToken);
}