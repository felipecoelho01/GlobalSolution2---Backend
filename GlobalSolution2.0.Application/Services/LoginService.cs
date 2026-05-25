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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public LoginService(ILoginRepository loginRepository, IConfiguration configuration, IUsuarioRepository usuarioRepository, IEmpresaRepository empresaRepository)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
            _empresaRepository = empresaRepository;
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
                    var login = logins.Where(_ => _.Email == model.Email && _.Password == model.Password && _.StateCode == true).FirstOrDefault();

                    if (login != null)
                    {
                        result = new LoginModelAPI()
                        {
                            AcessToken = GenerateToken(login.Id.ToString().ToUpper(), login.Email),
                            Email = login.Email,
                            Role = login.Role,
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

        public async Task<MensagemModel> Register(LoginModel login)
        {
            MensagemModel result = new MensagemModel();

            try
            {
                if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
                {
                    result.Mensagem = "Email e senha são obrigatórios.";
                    return result;
                }

                var logins = await _loginRepository.List();

                var verifyEmail = logins.Where(_ => _.Email == login.Email).FirstOrDefault();

                if (verifyEmail != null)
                {
                    result.Mensagem = "Já existe um usuário com esse E-mail.";
                    return result;
                }

                login.Id = Guid.NewGuid();

                await _loginRepository.Add(login);

                result.Mensagem = "Usuário cadastrado com sucesso.";
                return result;
            }
            catch (Exception ex)
            {
                result.Mensagem = "Erro na requisição.";
                return result;
            }
        }

    }
}
