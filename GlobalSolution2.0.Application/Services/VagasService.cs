using GlobalSolution2._0.Application.Interfaces;
using GlobalSolution2._0.Domain.Entities;
using GlobalSolution2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Application.Services
{
    public class VagasService : IVagasService
    {
        private readonly IVagasRepository _vagasRepository;

        public VagasService(IVagasRepository vagasRepository)
        {
            _vagasRepository = vagasRepository;
        }

        public async Task<List<VagaModel>> GetVagas()
        {
            try
            {
                var vagas = await _vagasRepository.List();

                return vagas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
