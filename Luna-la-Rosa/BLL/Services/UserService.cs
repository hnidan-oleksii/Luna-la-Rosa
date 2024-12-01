using AutoMapper;
using BLL.DTO.User;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers.Params;
using DAL.Repositories.Interfaces;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllUserAsync(UserParams userParams)
    {
        var searchFields = new List<string> { "FirstName", "LastName", "PhoneNumber", "Email" };
        var usersQuery = await _unitOfWork.User.GetAllUserAsync(userParams, searchFields);
        var users = usersQuery.ToList();

        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        return _mapper.Map<UserDto>(await _unitOfWork.User.GetByIdAsync(id));
    }

    public async Task<int> AddUserAsync(CreateUserDto userDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var user = _mapper.Map<User>(userDto);
            user.CreatedAt = DateTime.Now.ToUniversalTime();
            user.UpdatedAt = DateTime.Now.ToUniversalTime();
            user.Role = "user";
            await _unitOfWork.User.AddAsync(user);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return user.Id;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var user = _mapper.Map<User>(userDto);
            user.UpdatedAt = DateTime.Now.ToUniversalTime();
            await _unitOfWork.User.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task DeleteUserAsync(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _unitOfWork.User.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
    
    public async Task<UserDto?> AuthenticateAsync(LoginDto login)
    {
        var user = await _unitOfWork.User.AuthenticateAsync(login.Email, login.Password);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }

}
