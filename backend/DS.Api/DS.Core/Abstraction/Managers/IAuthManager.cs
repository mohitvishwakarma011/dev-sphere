namespace DS.Core.Abstraction.Managers
{
    public interface IAuthManager
    {
        Task<string> UserLogin(LoginModel model);
    }
}
