﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Boutique.Presentation.Commands.Auth
{
    public class LoginCommand
    {
        public LoginCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
