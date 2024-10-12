using BLL.DTO.AddOn;

namespace BLL.Services.Interfaces;

public interface IAddOnService
{
    Task<IEnumerable<AddOnDto>> GetAllAddOnsAsync();
    Task<Dictionary<string, List<AddOnDto>>> GetAddOnsGroupedByTypeAsync();
    Task AddAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken);
    Task UpdateAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken);
    Task DeleteAddOnAsync(int id, CancellationToken cancellationToken);
}