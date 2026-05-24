using GlobalSolution2._0.Domain.Entities;
using GlobalSolution2._0.Domain.Interfaces;
using GlobalSolution2._0.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(UsuarioModel usuario)
        {
            try 
            {
                if(usuario.Id == null)
                    usuario.Id = Guid.NewGuid();

                if (usuario.CreatedOn == null)
                    usuario.CreatedOn = DateTime.Now;

                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }

        public async Task Edit(UsuarioModel usuario)
        {
            try
            {
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public async Task<List<UsuarioModel>> List()
        {
            try 
            {
                return await _context.Usuario.ToListAsync();
            } 
            catch (Exception ex) 
            { 
                throw ex;
            }
        }
    }
}
