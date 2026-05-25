using GlobalSolution2._0.Domain.Entities;
using GlobalSolution2._0.Domain.Interfaces;
using GlobalSolution2._0.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Repositores
{
    public class VagaRepository : IVagasRepository
    {
        private readonly AppDbContext _context;
        public VagaRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task Add(VagaModel vaga)
        {
            try
            {
                if (vaga.Id == null)
                    vaga.Id = Guid.NewGuid();

                if (vaga.CreatedOn == null)
                    vaga.CreatedOn = DateTime.Now;

                await _context.Vaga.AddAsync(vaga);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Edit(VagaModel vaga)
        {
            try
            {
                _context.Vaga.Update(vaga);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VagaModel>> List()
        {
            try
            {
                return await _context.Vaga.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
