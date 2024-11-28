
using BLL.DTO.AddOn;
using DAL.Helpers.Params;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorFront.Services.Interfaces
{

    public interface IAddOnService
    {
        Task<IEnumerable<AddOnDto>> GetAllAddOnsAsync(string searchQuery);
        Task<Dictionary<string, List<AddOnDto>>> GetAddOnsGroupedByTypeAsync();
        Task<AddOnDto> GetAddOnByIdAsync(int id);
        Task<int> AddAddOnAsync(CreateAddOnDto addOnDto, CancellationToken cancellationToken);
        Task UpdateAddOnAsync(AddOnDto addOnDto, CancellationToken cancellationToken);
        Task DeleteAddOnAsync(int id, CancellationToken cancellationToken);
    }

}
