using GlobalSolution2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task Add(EmpresaModel login);
        Task Edit(EmpresaModel login);
        Task<List<EmpresaModel>> List();
    }
}
