using GlobalSolution2._0.Domain.Entities;
using GlobalSolution2._0.Domain.Interfaces;
using GlobalSolution2._0.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Repositores
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task Add(LoginModel login)
        {
            try
            {
                await _context.Login.AddAsync(login);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }  
        }

        public async Task Edit(LoginModel login)
        {
            try
            {
                _context.Login.Update(login);
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<List<LoginModel>> List()
        {
            try 
            {
                return await _context.Login.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
