using GlobalSolution2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Interfaces
{
    public interface IVagasRepository
    {
        Task Add(VagaModel vaga);
        Task Edit(VagaModel vaga);
        Task<List<VagaModel>> List();
    }
}
