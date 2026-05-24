using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Domain.Entities
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public LoginModel Login { get; set; }
        public Guid Login_id { get; set; }
        public string Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string? Telefone { get; set; }
         public string?Cidade { get; set; }
        public string?Estado { get; set; }
        public string?Curriculo_url { get; set; }
        public string? Resumo { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<CandidaturaModel> Candidaturas { get; set; }
    }
}
