

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
                Role = userModel.Role
            };
            await userRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
