namespace DS.Core.Abstraction.Repositories
{
    public interface IAuthRepository
    {
        Task<string> UserLogin(LoginModel model);
        Task<string> GenerateJwtTokenAsync(User user);
    }
}
