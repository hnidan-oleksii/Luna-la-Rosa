using BLL.DTO.User;
using DAL.Entities;
using DAL.Helpers.Params;

namespace BLL.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUserAsync(UserParams userParams);
    Task<UserDto> GetUserByIdAsync(int id);
    Task<int> AddUserAsync(CreateUserDto userDto, CancellationToken cancellationToken);
    Task UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken);
    Task DeleteUserAsync(int id, CancellationToken cancellationToken);
}