using BusinessLogic.ApiModels.Account;
using BusinessLogic.Entities;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Core.ApiModels.Account;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace BusinessLogic.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IJwtService jwtService;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountsService(IJwtService jwtService,
                               SignInManager<User> signInManager,
                               UserManager<User> userManager)
        {
            this.jwtService = jwtService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid login or password!", HttpStatusCode.BadRequest);

            await signInManager.SignInAsync(user, true);

            return new LoginResponse
            {
                Token = jwtService.CreateToken(jwtService.GetClaims(user))
            };
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterRequest model)
        {
            User user = new()
            {
                UserName = model.Email,
                Email = model.Email,
                Birthdate = model.Birthdate,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(", ", result.Errors.Select(x => x.Description));

                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
        }
    }
}
