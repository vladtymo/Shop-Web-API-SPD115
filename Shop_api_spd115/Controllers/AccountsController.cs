using BusinessLogic.ApiModels.Account;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Shop_api_spd115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            await accountsService.RegisterAsync(model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var response = await accountsService.LoginAsync(model);
            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountsService.LogoutAsync();
            return Ok();
        }
    }
}
