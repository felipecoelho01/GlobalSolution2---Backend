using GlobalSolution2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Application.Interfaces
{
    public interface IVagasService
    {
        Task<List<VagaModel>> GetVagas();
    }
}
