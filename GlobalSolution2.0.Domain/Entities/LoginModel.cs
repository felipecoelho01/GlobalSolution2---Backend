using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Entities
{
    public class LoginModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool? StateCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public EmpresaModel? Empresa { get; set; }
    }
}
