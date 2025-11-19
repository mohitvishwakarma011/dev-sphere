using DS.Core.Dto;
using DS.Core.Dto.User;
using System.Data;

namespace DS.Application.Managers
{
    public class UserManager : IUserManager
    {
        public IUserRepository userRepository;
        public IUnitOfWork unitOfWork;

        public UserManager(IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddUser(UserModel userModel)
        {
            User user = new User
            {
                PasswordHash = userModel.Password,
                UserName = userModel.UserName,
                UserEmail = userModel.UserEmail,
                Status = Constants.RecordStatus.Active

            };
            await userRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();
            await userRepository.AssignDefaultRole(user);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserModel userModel)
        {
            var user = await userRepository.GetByIdAsync(userModel.Id);

            if (user != null)
            {
                user.PasswordHash = userModel.Password;
                user.UserName = userModel.UserName;
                user.UserEmail = userModel.UserEmail;
                //user.Role = userModel.Role;
                user.Status = userModel.Status;

                userRepository.Update(user);
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                //Role = user.Role
            };
        }

        public async Task<TableResponseDto<UserDto>> GetListAsync()
        {
            var users = await userRepository.GetListAsync();
            return new TableResponseDto<UserDto>
            {
                TotalCount = users.Count,
                Items = users
            };
        }

        public async Task DeleteAsync(int id)
        {
            await userRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> IsExistAsyncByUserEmail(string email)
        {
            return await userRepository.IsExistAsyncByUserEmail(email);
        }
    }
}