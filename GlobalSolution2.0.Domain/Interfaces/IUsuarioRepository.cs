using GlobalSolution2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Add(UsuarioModel login);
        Task Edit(UsuarioModel login);
        Task<List<UsuarioModel>> List();
    }
}
