using GlobalSolution2._0.Application.Interfaces;
using GlobalSolution2._0.Domain.Entities;
using GlobalSolution2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository) 
        {
            _loginRepository = loginRepository;
        }

        public async Task<LoginModel> Login(LoginModel model)
        {
            try
            {
                LoginModel login = new LoginModel();

                var listLogin = await _loginRepository.List();

                if (listLogin.Any())
                {
                    var verifyEmail = listLogin.Where(_ => _.Email == model.Email && _.Password == login.Password);

                    if (verifyEmail.Any())
                        login = verifyEmail.FirstOrDefault();
                }

                return login;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
