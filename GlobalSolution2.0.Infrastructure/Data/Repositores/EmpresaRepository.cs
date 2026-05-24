using GlobalSolution2._0.Domain.Entities;
using GlobalSolution2._0.Domain.Interfaces;
using GlobalSolution2._0.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Repositores
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _context;

        public EmpresaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(EmpresaModel empresa)
        {
            try 
            {
                await _context.Empresa.AddAsync(empresa);
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex) 
            { 
                throw ex;
            }
        }

        public async Task Edit(EmpresaModel empresa)
        {
            try 
            {
                _context.Empresa.Update(empresa);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<List<EmpresaModel>> List()
        {
            try 
            {
                return await _context.Empresa.ToListAsync();
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
