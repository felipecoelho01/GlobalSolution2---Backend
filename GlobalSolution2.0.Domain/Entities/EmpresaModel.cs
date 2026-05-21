using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Entities
{
    public class EmpresaModel
    {
        public Guid Id { get; set; }
        public Guid Login_id { get; set; }
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? Setor { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Site { get; set; }
        public string? Descricao { get; set; }
        public string? Logo_url { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
