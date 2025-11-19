

using DS.Core.Dto;

namespace DS.Core.Abstraction.Managers
{
    public interface IUserManager
    {
        Task AddUser(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task<UserDto> GetByIdAsync(int id);
        Task<TableResponseDto<UserDto>> GetListAsync();
        Task DeleteAsync(int id);
        Task<bool> IsExistAsyncByUserEmail(string email);
    }
}
