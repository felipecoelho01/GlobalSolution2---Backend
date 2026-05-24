using GlobalSolution2._0.Application.Interfaces;
using GlobalSolution2._0.Application.Models;
using GlobalSolution2._0.Domain.Entities;
using GlobalSolution2._0.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GlobalSolution2._0.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        public async Task<LoginModelAPI?> Login(LoginModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                    return null;

                LoginModelAPI result = new LoginModelAPI();

                var logins = await _loginRepository.List();

                if (logins.Any())
                {
                    var login = logins.Where(_ => _.Email == model.Email && _.Password == model.Password && _.StateCode).FirstOrDefault();

                    if (login != null)
                    {
                        result = new LoginModelAPI()
                        {
                            AcessToken = GenerateToken(login.Id.ToString().ToUpper(), login.Email),

                        };
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateToken(string userId, string email)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, email)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<MensagemModel> Register(LoginModel model)
        {
            try
            {
                MensagemModel result = new MensagemModel();

                var logins = await _loginRepository.List();

                var verifyEmail = logins.Where(_ => _.Email == model.Email).FirstOrDefault();

                if (verifyEmail != null)
                    result.Mensagem = "Já existe um usuário com esse E-mail.";

                await _loginRepository.Add(model);

                result.Mensagem = "Usuário cadastrado com sucesso.";
                return result;     
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
