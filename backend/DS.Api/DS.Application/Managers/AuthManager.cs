namespace DS.Application.Managers
{
    public class AuthManager(IAuthRepository authRepository):IAuthManager
    {
        public async Task<string> UserLogin(LoginModel model)
        {
           return await authRepository.UserLogin(model);
        }
    }
}
