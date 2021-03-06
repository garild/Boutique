﻿using System.Threading.Tasks;
using Auth.Provider;
using Boutique.Presentation.Commands.Auth;

namespace Boutique.Infrastructure.Services
{
    public interface IUserService
    {
        Task<JsonWebToken> Login(LoginCommand command);
        Task<string> Register(RegisterCommand command);
    }
}
