using BLL.DTO;

namespace BLL.Services.Interfaces;

public interface IAddOnService
{
    Task<Dictionary<string, List<AddOnDto>>> GetAddOnsGroupedByTypeAsync();
    Task AddAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken);
    Task UpdateAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken);
    Task DeleteAddOnAsync(int id, CancellationToken cancellationToken);
}