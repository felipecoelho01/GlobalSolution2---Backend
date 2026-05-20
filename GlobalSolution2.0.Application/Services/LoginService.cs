using GlobalSolution2._0.Application.Interfaces;
using GlobalSolution2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Application.Services
{
    public class LoginService : ILoginService
    {
        public async Task<LoginModel> Login(LoginModel model)
        {
            try
            {
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
