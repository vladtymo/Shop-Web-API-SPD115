using BusinessLogic.ApiModels.Account;

namespace BusinessLogic.Interfaces
{
    public interface IAccountsService
    {
        Task RegisterAsync(RegisterRequest model);
        Task LoginAsync(LoginRequest model);
        Task LogoutAsync();
    }
}
