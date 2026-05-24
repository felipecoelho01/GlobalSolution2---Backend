using GlobalSolution2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Application.Models
{
    public class LoginModelAPI : LoginModel
    {
        public string AcessToken { get; set; }
        public string Name { get; set; }
    }
}
