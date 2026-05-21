using GlobalSolution2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task Add(LoginModel login);
        Task Edit(LoginModel login);
        Task<List<LoginModel>> List();
    }
}
