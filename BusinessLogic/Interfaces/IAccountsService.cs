using BusinessLogic.ApiModels.Account;
using Core.ApiModels.Account;

namespace BusinessLogic.Interfaces
{
    public interface IAccountsService
    {
        Task RegisterAsync(RegisterRequest model);
        Task<LoginResponse> LoginAsync(LoginRequest model);
        Task LogoutAsync();
    }
}
