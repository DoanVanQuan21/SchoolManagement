﻿using SchoolManagement.Auth.Contracts;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Models.SchoolManagements;

namespace SchoolManagement.Auth.Services
{
    internal class LoginService : ILoginService
    {
        private readonly IAppManager _appManager;

        public LoginService()
        {
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public bool Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}